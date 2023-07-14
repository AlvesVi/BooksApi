using BooksApi.Model;

namespace BooksApi.Repositories.Contracts
{
    public interface IListaLivrosRepositorio
    {
        List<ListadeLeitura> ListasdeLeitura();
        ListadeLeitura BuscaPorId(int id);
        LivrodaLista BuscaLivroDaLista(int listaId, int livroId);
        List<LivrodaLista> LivrosdaLista(int id);
        ListadeLeitura CadastrarListaLeitura(ListadeLeitura listaLeitura);
        LivrodaLista AdicionarLivroNaLista(int listaId, int livroId);
        void ExcluirLivroDaLista(LivrodaLista livroDaLista);
        void AlterarStatusDeLido(LivrodaLista livroDaLista, bool lido);
        List<LivrodaLista> BuscaListaPorLivro(int livroId);
    }
}
