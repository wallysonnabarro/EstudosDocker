using EstudosDocker.domain;
using EstudosDocker.services.interfaces;
using MassTransit;

namespace EstudosDocker.services.services
{
    public class MessagePublisher(IBus bus) : IMessagePublisher
    {
        public async Task<bool> ExecuteAsync(LivroDto dto, CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(dto, stoppingToken);
            }

            return true;
        }
    }
}
