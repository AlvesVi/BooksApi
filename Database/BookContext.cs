using BooksApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Database
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivrodaLista> LivrosdaLista { get; set; }
        public DbSet<ListadeLeitura> ListasdeLeitura { get; set; }


        //Seeds
        public class DbInitializer
        {
            private readonly ModelBuilder modelBuilder;

            public DbInitializer(ModelBuilder modelBuilder)
            {
                this.modelBuilder = modelBuilder;
            }

            public void Seed()
            {
                modelBuilder.Entity<Genero>().HasData(
                    new Genero() { Id = 1, Descricao = "Romance" },
                    new Genero() { Id = 2, Descricao = "Terror" },
                    new Genero() { Id = 3, Descricao = "Comédia" },
                    new Genero() { Id = 4, Descricao = "Ação e aventura" },
                    new Genero() { Id = 5, Descricao = "Infantil" },
                    new Genero() { Id = 6, Descricao = "Ficção Cristã" }
                );

                modelBuilder.Entity<Livro>().HasData(
                    new Livro() { Id = 1, Titulo = "Harry Potter", GeneroId = 4, DataPublicacao=DateTime.Now },
                    new Livro() { Id = 2, Titulo = "O Pequeno Príncipe", GeneroId = 5, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 3, Titulo = "A Cabana", GeneroId = 6, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 4, Titulo = "A Cinco Passos de Você", GeneroId = 1, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 5, Titulo = "Chá de Sumiço", GeneroId = 3, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 6, Titulo = "Star Wars", GeneroId = 4, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 7, Titulo = "Frankenstein", GeneroId = 2, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 8, Titulo = "Orgulho e Preconceito", GeneroId = 1, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 9, Titulo = "A culpa é das estrelas", GeneroId = 1, DataPublicacao = DateTime.Now },
                    new Livro() { Id = 10, Titulo = "A pequena sereia", GeneroId = 5, DataPublicacao = DateTime.Now }
                );
            }
        }
    }
}
