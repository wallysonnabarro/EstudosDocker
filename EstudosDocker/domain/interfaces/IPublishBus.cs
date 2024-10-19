namespace EstudosDocker.domain.interfaces
{
    public interface IPublishBus
    {
        Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class;
    }
}
