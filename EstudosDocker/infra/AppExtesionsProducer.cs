﻿using EstudosDocker.domain.Bus;
using EstudosDocker.domain.interfaces;
using EstudosDocker.infra.infra;
using EstudosDocker.infra.interfaces;
using EstudosDocker.services.interfaces;
using EstudosDocker.services.services;
using MassTransit;

namespace EstudosDocker.infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPublishBus, PublishBus>();
            services.AddTransient<ILivrosInfra, LivrosInfra>();
            services.AddTransient<ILivrosServices, LivrosServices>();

            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("amqp://rabbitmq:5672"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
