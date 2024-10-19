using EstudosDocker.domain;
using EstudosDocker.domain.Eventes;
using EstudosDocker.domain.interfaces;
using EstudosDocker.infra.interfaces;
using EstudosDocker.services.interfaces;

namespace EstudosDocker.infra.infra
{
    public class LivrosInfra : ILivrosInfra
    {
        private readonly IPublishBus bus;
        private readonly ILivrosServices services;

        public LivrosInfra(IPublishBus bus, ILivrosServices services)
        {
            this.bus = bus;
            this.services = services;
        }

        public async Task<Result<bool>> NovoLivroPublish(LivroDto livro, CancellationToken ct)
        {
            try
            {
                var validar = await services.ValidarDadosLivro(livro);
                if (!validar.Succeeded)
                    return validar;

                //ListaLivros.Lista.Add(livro);

                var eventRequest = new LivroEvent(livro.Nome, livro.Titulo, livro.Descricao);

                await bus.PublishAsync(eventRequest, ct);

                return Result<bool>.Success;
            }
            catch (Exception e)
            {
                return new Result<bool>(new Errors { mensagem = e.Message });
            }
        }
    }
}
