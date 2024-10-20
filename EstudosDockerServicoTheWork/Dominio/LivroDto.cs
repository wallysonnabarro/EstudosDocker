namespace EstudosDockerServicoTheWork.Dominio
{
    internal class LivroDto
    {
        public required string Nome { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
    }
}
