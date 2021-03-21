using MassTransit;
using MassTransit.Definition;
using MassTransit.ExtensionsDependencyInjectionIntegration;

namespace DR.Packages.MassTransit
{
    public static class Extensions
    {
        /// <summary>
        /// connection string must be provides as "Host=localhost;Port=5672;Username=admin;Password=admin;ApplicationName=xxx" with optional application name
        /// </summary>
        public static void UseRabbitMq(this IServiceCollectionBusConfigurator container, string connectionString)
        {
            var rabbitMq = new RabbitMqOptions(connectionString);
            container.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMq.Host, rabbitMq.Port, rabbitMq.VHost, rabbitMq.ApplicationName, h =>
                {
                    h.Username(rabbitMq.Username);
                    h.Password(rabbitMq.Password);
                });

                cfg.ConfigureEndpoints(context, new DefaultEndpointNameFormatter(true));
            });
        }
    }
}
