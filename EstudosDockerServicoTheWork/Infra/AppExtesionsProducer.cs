using EstudosDockerServicoTheWork.Infra.Interface;
using EstudosDockerServicoTheWork.Infra.Repositorys;
using EstudosDockerServicoTheWork.Services;

namespace EstudosDockerServicoTheWork.Infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ILivroRepository, LivrosRepository>();
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
