using EstudosDockerServicoTheWork.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EstudosDockerServicoTheWork.Infra
{
    internal class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Livro[] livros =
                [
                    new Livro{ Nome = "Inicializar", Titulo = "Inicializar", Id = new Guid("4e4c8abf-f3f0-4488-9d08-fd109ae04feb")}
                ];

            modelBuilder.Entity<Livro>().HasData(livros);

            base.OnModelCreating(modelBuilder);
        }
    }
}
