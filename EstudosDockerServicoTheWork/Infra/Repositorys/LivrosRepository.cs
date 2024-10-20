using EstudosDockerServicoTheWork.Dominio;
using EstudosDockerServicoTheWork.Infra.Interface;

namespace EstudosDockerServicoTheWork.Infra.Repositorys
{
    internal class LivrosRepository : ILivroRepository
    {
        private readonly ContextDb _db;

        public LivrosRepository(ContextDb db)
        {
            _db = db;
        }

        public async Task<Result<bool>> GravarLivro(LivroDto dto)
        {
            try
            {
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
            catch (Exception e)
            {
                return new Result<bool>(new Errors { mensagem = e.Message });
            }
        }
    }
}
