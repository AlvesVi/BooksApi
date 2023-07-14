using BooksApi.Database;
using BooksApi.Model;
using BooksApi.Repositories.Contracts;

namespace BooksApi.Repositories
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private BookContext _banco;

        public GeneroRepositorio(BookContext banco)
        {
            _banco = banco;
        }

        public List<Genero> ListaGeneros()
        {
            return _banco.Generos.ToList();
        }

        public Genero BuscarPorId(int id)
        {
            return _banco.Generos.Find(id);
        }

        public Genero BuscarPorDescricao(string descricao)
        {
            return _banco.Generos.FirstOrDefault(x => x.Descricao == descricao);
        }

        public Genero CadastrarGenero(Genero genero)
        {
            _banco.Generos.Add(genero);
            _banco.SaveChanges();
            return genero;
        }

        public Genero AlterarGenero(Genero genero)
        {
            _banco.Generos.Update(genero);
            _banco.SaveChanges();
            return genero;
        }

        public void ExcluirGenero(int id)
        {
            var genero = BuscarPorId(id);
            if (genero != null)
            {
                _banco.Generos.Remove(genero);
                _banco.SaveChanges();
            }
        }
    }
}
