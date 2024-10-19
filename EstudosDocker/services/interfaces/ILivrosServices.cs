using EstudosDocker.domain;

namespace EstudosDocker.services.interfaces
{
    public interface ILivrosServices
    {
        Task<Result<bool>> ValidarDadosLivro(LivroDto livro);
    }
}
