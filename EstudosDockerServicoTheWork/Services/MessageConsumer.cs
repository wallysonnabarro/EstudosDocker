using EstudosDockerServicoTheWork.Dominio;
using EstudosDockerServicoTheWork.Infra.Interface;
using MassTransit;

namespace EstudosDockerServicoTheWork.Services
{
    public class MessageConsumer(ILivroRepository repository) : IConsumer<LivroDto>
    {
        Task IConsumer<LivroDto>.Consume(ConsumeContext<LivroDto> context)
        {
            repository.GravarLivro(context.Message);

            return Task.CompletedTask;
        }
    }
}
