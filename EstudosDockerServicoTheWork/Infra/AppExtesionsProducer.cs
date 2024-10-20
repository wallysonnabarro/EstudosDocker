using EstudosDockerServicoTheWork.Infra.Interface;
using EstudosDockerServicoTheWork.Infra.Repositorys;

namespace EstudosDockerServicoTheWork.Infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ILivroRepository, LivrosRepository>();
        }
    }
}
