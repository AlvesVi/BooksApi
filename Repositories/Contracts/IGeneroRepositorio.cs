using BooksApi.Model;

namespace BooksApi.Repositories.Contracts
{
    public interface IGeneroRepositorio
    {
        List<Genero> ListaGeneros();
        Genero BuscarPorId(int id);
        Genero BuscarPorDescricao(string descricao);
        Genero CadastrarGenero(Genero genero);
        Genero AlterarGenero (Genero genero);
        void ExcluirGenero (int id);
    }

}
