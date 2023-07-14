using BooksApi.Model;

namespace BooksApi.Repositories.Contracts
{
    public interface ILivroRepositorio
    {
        List<Livro> ListaLivro();
        Livro BuscarPorId(int id);
        List<Livro> BuscarPorTitulo(string titulo);
        List<Livro> BuscarPorGeneroId(int id);
        Livro CadastrarLivro(Livro livro);
        Livro AlterarLivro(Livro livro);
        void ExcluirLivro(int id);
    }
}
