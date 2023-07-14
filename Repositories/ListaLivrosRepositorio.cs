using BooksApi.Database;
using BooksApi.Model;
using BooksApi.Repositories.Contracts;

namespace BooksApi.Repositories
{
    public class ListaLivrosRepositorio : IListaLivrosRepositorio
    {
        private BookContext _banco;

        public ListaLivrosRepositorio(BookContext banco)
        {
            _banco = banco;
        }

        public List<ListadeLeitura> ListasdeLeitura()
        {
            return _banco.ListasdeLeitura.ToList();
            //return _banco.ListasdeLeitura.Where(x => x.Id == id).ToList();
        }
        public ListadeLeitura BuscaPorId(int id)
        {
            return _banco.ListasdeLeitura.Find(id);
        }
             
        public List<LivrodaLista> LivrosdaLista(int listaId)
        {
            return _banco.LivrosdaLista.Where(x => x.ListaId == listaId).ToList();
        }

        public LivrodaLista AdicionarLivroNaLista(int listaId, int livroId)
        {
            var livroDaLista = new LivrodaLista
            {
                ListaId = listaId,
                LivroId = livroId,
                Lido = false
            };
            _banco.LivrosdaLista.Add(livroDaLista);
            _banco.SaveChanges();

            var listaLeitura = BuscaPorId(listaId);
            listaLeitura.QtdeLivros++;
            _banco.ListasdeLeitura.Update(listaLeitura);
            _banco.SaveChanges();

            return livroDaLista;
        }

        public ListadeLeitura CadastrarListaLeitura(ListadeLeitura listaLeitura)
        {
            _banco.ListasdeLeitura.Add(listaLeitura);
            _banco.SaveChanges();
            return listaLeitura;
        }

        public void ExcluirLivroDaLista(LivrodaLista livroDaLista)
        {
            _banco.LivrosdaLista.Remove(livroDaLista);
            _banco.SaveChanges();

            var listaDeLeitura = BuscaPorId(livroDaLista.ListaId);
            listaDeLeitura.QtdeLivros--;
            _banco.ListasdeLeitura.Update(listaDeLeitura);
            _banco.SaveChanges();
        }

        public LivrodaLista BuscaLivroDaLista(int listaId, int livroId)
        {
            return _banco.LivrosdaLista.FirstOrDefault(x => x.LivroId == livroId && x.ListaId == listaId);
        }

        public void AlterarStatusDeLido(LivrodaLista livroDaLista, bool lido)
        {
            var livroDaListaAtual = BuscaLivroDaLista(livroDaLista.ListaId, livroDaLista.LivroId);
            
            // só altera a quantidade de livros lidos, caso tenha alteração no status atual do livro
            if (livroDaListaAtual.Lido != lido)
            {
                livroDaLista.Lido = lido;
                var listaDeLeitura = BuscaPorId(livroDaLista.ListaId);
                if (lido)
                {
                    listaDeLeitura.QtdeLivrosLidos++;
                } else
                {
                    listaDeLeitura.QtdeLivrosLidos--;
                }
            _banco.LivrosdaLista.Update(livroDaLista);
            _banco.ListasdeLeitura.Update(listaDeLeitura);
            _banco.SaveChanges();
            }
        }

        public List<LivrodaLista> BuscaListaPorLivro(int livroId)
        {
            return _banco.LivrosdaLista.Where(x => x.LivroId == livroId).ToList();
        }
    }
}
