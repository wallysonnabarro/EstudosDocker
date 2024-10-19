using EstudosDocker.domain;

namespace EstudosDocker.infra.interfaces
{
    public interface ILivrosInfra
    {
        Task<Result<bool>> NovoLivroPublish(LivroDto livro, CancellationToken ct);
    }
}
