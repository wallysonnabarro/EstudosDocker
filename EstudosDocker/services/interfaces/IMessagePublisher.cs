﻿using Dominio;

namespace EstudosDocker.services.interfaces
{
    public interface IMessagePublisher
    {
        Task<bool> ExecuteAsync(LivroDto dto ,CancellationToken stoppingToken);
    }
}
