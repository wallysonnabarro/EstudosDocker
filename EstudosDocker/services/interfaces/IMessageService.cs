using EstudosDocker.domain;

namespace EstudosDocker.services.interfaces
{
    public interface IMessageService
    {
        Task<bool> Enqueue(LivroDto livro, CancellationToken ct);
    }
}