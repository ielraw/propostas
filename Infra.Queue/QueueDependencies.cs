using Domain.Entities;
using Infra.Queue.Consumers;
using Infra.Queue.Interfaces;
using Infra.Queue.Publishers;
using Infra.Queue.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infra.Queue
{
    public static class QueueDependencies
    {

        public static IServiceCollection AddQueueServices(this IServiceCollection services, Action<RabbitMQSettings> config)
        {
            services.Configure<RabbitMQSettings>(config);
            services.AddSingleton<IMessageBusPublisher, RabbitMQPublisher>();

            return services;
        }

        public static IServiceCollection AddQueueConsumer<T, THandler>(
            this IServiceCollection services,
            string queue) where T : class where THandler : class, IMessageHandler<T>
        {
            services.AddScoped<IMessageHandler<T>, THandler>();
            services.AddHostedService(sp =>
                new RabbitMQConsumer<T>(
                    sp.GetRequiredService<IOptions<RabbitMQSettings>>(),
                    sp,
                    sp.GetRequiredService<ILogger<RabbitMQConsumer<T>>>(),
                    queue));

            return services;
        }

        public static void AddQueueDependencies(this IServiceCollection services)
        {

        }
    }
}
