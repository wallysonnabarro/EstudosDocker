﻿namespace EstudosDocker.domain
{
    public class LivroDto
    {
        public required string Nome { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
    }
}
