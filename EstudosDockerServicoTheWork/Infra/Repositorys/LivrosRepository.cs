using EstudosDockerServicoTheWork.Dominio;
using EstudosDockerServicoTheWork.Infra.Interface;

namespace EstudosDockerServicoTheWork.Infra.Repositorys
{
    internal class LivrosRepository : ILivroRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public LivrosRepository(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<Result<bool>> GravarLivro(LivroDto dto)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _db = scope.ServiceProvider.GetRequiredService<ContextDb>();

                    var novo = new Livro
                    {
                        Nome = dto.Nome,
                        Titulo = dto.Titulo,
                        DataProcessado = DateTime.Now,
                        Descricao = dto.Descricao,
                    };

                    _db.Add(novo);
                    await _db.SaveChangesAsync();

                    return Result<bool>.Success;
                }
            }
            catch (Exception e)
            {
                return new Result<bool>(new Errors { mensagem = e.Message });
            }
        }
    }
}
