using EstudosDocker.domain;
using EstudosDocker.services.interfaces;
using EstudosDocker.services.services;
using MassTransit;

namespace EstudosDocker.infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services, IConfiguration builder)
        {
            services.AddSingleton<ILivrosServices, LivrosServices>();

            services.AddScoped<IMessagePublisher, MessagePublisher>();

            services.AddMassTransit(bus =>
            {
                bus.AddDelayedMessageScheduler();
                bus.SetKebabCaseEndpointNameFormatter();

                bus.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(builder["MessageBroker:Host"]!), h =>
                    {
                        h.Username(builder["MessageBroker:Username"]!);
                        h.Password(builder["MessageBroker:Password"]!);
                    });

                    cfg.UseDelayedMessageScheduler();

                    cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("dev", false));

                    cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
                });
            });
        }
    }
}
