using BooksApi.Model;
using BooksApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaLivrosController : Controller
    {
        private readonly IListaLivrosRepositorio _listaLivroRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;

        public ListaLivrosController(IListaLivrosRepositorio listaLivroRepositorio, ILivroRepositorio livroRepositorio)
        {
            _listaLivroRepositorio = listaLivroRepositorio;
            _livroRepositorio = livroRepositorio;
        }

        /// <summary>
        /// Exibe todas as listas de leitura cadastrada no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/ListaDeLeitura")]
        public IActionResult ListaLeitura()
        {
            var listaLeitura = _listaLivroRepositorio.ListasdeLeitura();
            return Ok(listaLeitura);
        }

        /// <summary>
        /// Exibe todos os livros cadastrados para uma determinada lista de leitura
        /// </summary>
        /// <param name="listaId"></param>
        /// <returns></returns>
        [HttpGet("/api/ObterLivrosDaLista")]
        public IActionResult ObterLivrosDaLista(int listaId)
        {
            var livrosDaLista = _listaLivroRepositorio.LivrosdaLista(listaId);
            return Ok(livrosDaLista);
        }

        /// <summary>
        /// Realiza o cadastro de uma nova lista de leitura
        /// </summary>
        /// <param name="listaLeitura"></param>
        /// <returns></returns>
        [HttpPost("/api/CadastrarListaLeitura")]
        public IActionResult CadastrarListaLeitura(ListadeLeitura listaLeitura)
        {
            _listaLivroRepositorio.CadastrarListaLeitura(listaLeitura);
            return Ok(listaLeitura);
        }

        /// <summary>
        /// Adiciona um livro à uma lista de leitura
        /// </summary>
        /// <param name="listaId"></param>
        /// <param name="livroId"></param>
        /// <returns></returns>
        [HttpPost("/api/AdicionarLivroNaLista")]
        public IActionResult AdicionarLivroNaLista(int listaId, int livroId)
        {
            try
            {
                var listaLeitura = _listaLivroRepositorio.BuscaPorId(listaId);
                if (listaLeitura == null)
                {
                    return BadRequest($"A lista com o id {listaId} não foi encontrada");
                }

                var livro = _livroRepositorio.BuscarPorId(livroId);
                if (livro == null)
                {
                    return BadRequest($"O livro com o id {livroId} não foi encontrado");
                }

                var livroDaLista = _listaLivroRepositorio.BuscaLivroDaLista(listaId, livroId);
                if (livroDaLista != null)
                {
                    return BadRequest($"O livro com o id {livroId} já está cadastrado na lista com id {listaId}");
                }
                _listaLivroRepositorio.AdicionarLivroNaLista(listaId, livroId);
                return RedirectToAction(nameof(ObterLivrosDaLista), new { listaId = listaId});
            } catch (Exception ex)
            {
                return BadRequest("Erro ao realizar o processamento: " + ex.Message);
            }
        }

        /// <summary>
        /// Exclui um livro da lista de leitura
        /// </summary>
        /// <param name="listaId"></param>
        /// <param name="livroId"></param>
        /// <returns></returns>
        [HttpDelete("/api/ExcluirLivroDaLista")]
        public IActionResult ExcluirLivroLista(int listaId, int livroId)
        {
            try
            {
                var listaDeLivro = _listaLivroRepositorio.BuscaPorId(listaId);
                if (listaDeLivro == null)
                {
                    return BadRequest($"Lista com o id {listaId} não encontrada");
                }
                var livroDaLista = _listaLivroRepositorio.BuscaLivroDaLista(listaId, livroId);
                if (livroDaLista == null)
                {
                    return BadRequest($"Livro com o id {livroId} não encontrado na lista {listaId}");
                }

                _listaLivroRepositorio.AlterarStatusDeLido(livroDaLista, false);
                _listaLivroRepositorio.ExcluirLivroDaLista(livroDaLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Livro excluído da lista com sucesso");
        }

        /// <summary>
        /// Altera o status de LIDO para um livro da lista de leitura
        /// </summary>
        /// <param name="listaId"></param>
        /// <param name="livroId"></param>
        /// <param name="lido"></param>
        /// <returns></returns>
        [HttpPut("/api/AlterarStatusDeLivo")]
        public IActionResult AlterarStatusDeLido(int listaId, int livroId, bool lido)
        {
            try
            {
                var listaDeLivro = _listaLivroRepositorio.BuscaPorId(listaId);
                if (listaDeLivro == null)
                {
                    return BadRequest($"Lista com o id {listaId} não encontrada");
                }
                var livroDaLista = _listaLivroRepositorio.BuscaLivroDaLista(listaId, livroId);
                if (livroDaLista == null)
                {
                    return BadRequest($"Livro com o id {livroId} não encontrado na lista {listaId}");
                }

                _listaLivroRepositorio.AlterarStatusDeLido(livroDaLista, lido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Status do livro alterado com sucesso!");
        }
    }
}
