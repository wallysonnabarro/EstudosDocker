using EstudosDocker.services.interfaces;
using EstudosDocker.services.services;

namespace EstudosDocker.infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ILivrosServices, LivrosServices>();

            services.AddSingleton<IMessageService, MessageService>();
        }
    }
}
