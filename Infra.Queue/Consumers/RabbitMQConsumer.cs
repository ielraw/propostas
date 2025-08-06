using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Infra.Queue.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infra.Queue.Interfaces;

namespace Infra.Queue.Consumers
{
    public class RabbitMQConsumer<T> : BackgroundService where T : class
    {
        private readonly IConnection _connection;
        private readonly IChannel _channel;
        private readonly string _queue;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RabbitMQConsumer<T>> _logger;

        public RabbitMQConsumer(
            IOptions<RabbitMQSettings> settings,
            IServiceProvider serviceProvider,
            ILogger<RabbitMQConsumer<T>> logger,
            string queue)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _queue = queue;

            var factory = new ConnectionFactory
            {
                HostName = settings.Value.HostName,
                UserName = settings.Value.UserName,
                Password = settings.Value.Password
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;

            _channel.QueueDeclareAsync(
                queue: _queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (sender, eventArgs) =>
            {
                try
                {
                    var contentArray = eventArgs.Body.ToArray();
                    var contentString = Encoding.UTF8.GetString(contentArray);
                    var message = JsonSerializer.Deserialize<T>(contentString);

                    await ProcessMessageAsync(message);

                    await _channel.BasicAckAsync(eventArgs.DeliveryTag, false, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar mensagem da fila {Queue}", _queue);
                    await _channel.BasicNackAsync(eventArgs.DeliveryTag, false, true, stoppingToken);
                }
            };

            _channel.BasicConsumeAsync(_queue, false, consumer, stoppingToken);

            return Task.CompletedTask;
        }

        private async Task ProcessMessageAsync(T message)
        {
            using var scope = _serviceProvider.CreateScope();
            var messageHandler = scope.ServiceProvider.GetRequiredService<IMessageHandler<T>>();
            await messageHandler.HandleAsync(message);
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }
    }
}