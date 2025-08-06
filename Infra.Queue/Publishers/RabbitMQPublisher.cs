using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Infra.Queue.Interfaces;
using Infra.Queue.Settings;
using System.Threading.Channels;

namespace Infra.Queue.Publishers
{
    public class RabbitMQPublisher : IMessageBusPublisher, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IChannel _channel;
        private readonly RabbitMQSettings _settings;

        public RabbitMQPublisher(IOptions<RabbitMQSettings> settings)
        {
            _settings = settings.Value;

            var factory = new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;
        }

        public async Task PublishAsync<T>(string queue, T message) where T : class
        {
            await _channel.QueueDeclareAsync(
                queue: queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);


            await _channel.BasicPublishAsync(
                exchange: "",
                routingKey: queue,
                body: body);

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}