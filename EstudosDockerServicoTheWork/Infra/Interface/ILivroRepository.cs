using EstudosDockerServicoTheWork.Dominio;

namespace EstudosDockerServicoTheWork.Infra.Interface
{
    internal interface ILivroRepository
    {
        Task<Result<bool>> GravarLivro(LivroDto dto);
    }
}
