using Dominio;
using EstudosDocker.services.interfaces;

namespace EstudosDocker.Controllers
{
    internal static class ApiEndpoints
    {
        public static void AddApiEndpoints(this WebApplication app)
        {
            //app.MapGet("livros", () => ListaLivros.Lista);

            app.MapPost("registrar-livro", async (LivroDto livro, IMessagePublisher message, CancellationToken ct = default) =>
            {
                var result = await message.ExecuteAsync(livro, ct);

                return Results.Ok(result);
            });
        }
    }
}
