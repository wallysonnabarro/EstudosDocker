using EstudosDockerServicoTheWork.Dominio;

namespace EstudosDockerServicoTheWork.Infra.Interface
{
    public interface ILivroRepository
    {
        Task<Result<bool>> GravarLivro(LivroDto dto);
    }
}
