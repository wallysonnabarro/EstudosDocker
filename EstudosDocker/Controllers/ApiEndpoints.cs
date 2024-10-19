using EstudosDocker.domain;
using EstudosDocker.infra.interfaces;

namespace EstudosDocker.Controllers
{
    internal static class ApiEndpoints
    {
        public static void AddApiEndpoints(this WebApplication app)
        {
            //app.MapGet("livros", () => ListaLivros.Lista);

            app.MapPost("registrar-livro", async (LivroDto livro, ILivrosInfra infra, CancellationToken ct = default) =>
            {
                var novo = new LivroDto()
                {
                    Nome = livro.Nome,
                    Titulo = livro.Titulo,
                    Descricao = livro.Descricao,
                };

                var result = await infra.NovoLivroPublish(novo, ct);

                return Results.Ok(result);
            });
        }
    }
}
