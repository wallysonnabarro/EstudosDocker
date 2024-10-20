using EstudosDocker.domain;
using EstudosDocker.services.interfaces;

namespace EstudosDocker.Controllers
{
    internal static class ApiEndpoints
    {
        public static void AddApiEndpoints(this WebApplication app)
        {
            //app.MapGet("livros", () => ListaLivros.Lista);

            app.MapPost("registrar-livro", async (LivroDto livro, IMessageService message, CancellationToken ct = default) =>
            {
                var result = await message.Enqueue(livro, ct);

                return Results.Ok(result);
            });
        }
    }
}
