namespace EstudosDockerServicoTheWork.Dominio
{
    internal class Livro
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataProcessado { get; set; }
    }
}
