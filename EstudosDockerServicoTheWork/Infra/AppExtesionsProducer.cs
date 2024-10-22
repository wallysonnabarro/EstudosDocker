using EstudosDockerServicoTheWork.Infra.Interface;
using EstudosDockerServicoTheWork.Infra.Repositorys;
using EstudosDockerServicoTheWork.Services;
using MassTransit;

namespace EstudosDockerServicoTheWork.Infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services, IConfiguration builder)
        {
            services.AddTransient<ILivroRepository, LivrosRepository>();

            services.AddMassTransit(bus =>
            {
                bus.AddDelayedMessageScheduler();
                bus.SetKebabCaseEndpointNameFormatter();

                bus.AddConsumer<MessageConsumer>();

                bus.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(builder["MessageBroker:Host"]!), h =>
                    {
                        h.Username(builder["MessageBroker:Username"]!);
                        h.Password(builder["MessageBroker:Password"]!);
                    });

                    cfg.UseDelayedMessageScheduler();

                    cfg.ServiceInstance(instance =>
                    {
                        instance.ConfigureJobServiceEndpoints();
                        instance.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("dev", false));
                    });
                });
            });

            services.AddMassTransitHostedService(true);
        }
    }
}
