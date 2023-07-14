using BooksApi.Model;
using BooksApi.Repositories;
using BooksApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IListaLivrosRepositorio _listaLivrosRepositorio;
      
        public LivroController(ILivroRepositorio livroRepositorio, IListaLivrosRepositorio listaLivrosRepositorio)
        {
            _livroRepositorio = livroRepositorio;
            _listaLivrosRepositorio = listaLivrosRepositorio;
        }
        /// <summary>
        /// Lista todos os Livros cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/ListarLivros")]
        public IActionResult ListarLivros()
        {
            var livros = _livroRepositorio.ListaLivro();
            return Ok(livros);
        }

        /// <summary>
        /// Realiza a busca de um Livro pelo ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var genero = _livroRepositorio.BuscarPorId(id);
            return genero == null ? BadRequest($"Genero com o id {id} não encontrado") : Ok(genero);
        }
        /// <summary>
        /// Realiza a busca de um Livro pelo Título informado
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        [HttpGet("/api/BuscarPorTitulo/{titulo}")]
        public IActionResult BuscarPorTitulo(string titulo)
        {
            var livro = _livroRepositorio.BuscarPorTitulo(titulo);
            return livro == null ? BadRequest($"Título {titulo} não encontrado") : Ok(livro);
        }
        /// <summary>
        /// Retorna todos os livros cadastrados com o gênero informado
        /// </summary>
        /// <param name="generoid"></param>
        /// <returns></returns>
        [HttpGet("/api/BuscarLivrosPorGenero")]
        public IActionResult BuscarLivrosPorGenero(int generoid)
        {
            var livro = _livroRepositorio.BuscarPorGeneroId(generoid);
            return livro == null ? BadRequest($"Nunhum livro foi encontrado com esse gênero {generoid}") : Ok(livro);
        }
        /// <summary>
        /// Cadastra um novo Livro
        /// </summary>
        /// <param name="livro"></param>
        /// <returns></returns>
        [HttpPost("/api/CadastrarLivro")]
        public IActionResult CadastrarLivro(Livro livro)
        {
            var buscaLivro = _livroRepositorio.BuscarPorTitulo(livro.Titulo);
            if (buscaLivro != null)
            {
                return BadRequest($"Já existe um gênero cadastrado com a descrição {livro.Titulo}");
            }
            _livroRepositorio.CadastrarLivro(livro);
            return Ok(livro);
        }

        /// <summary>
        /// Alteração de informações do livro
        /// </summary>
        /// <param name="livro"></param>
        /// <returns></returns>
        [HttpPut ("/api/AlterarLivros")]
        public IActionResult AlterarLivros(Livro livro)
        {
            _livroRepositorio.AlterarLivro(livro);
            return Ok(livro);
        }

        /// <summary>
        /// Exclusão do livro informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("/api/ExcluirLivro")]
        public IActionResult ExcluirLivro(int id)
        {
            try
            {
                var livro = _livroRepositorio.BuscarPorId(id);
                if (livro == null)
                {
                    return BadRequest($"Livro com o id {id} não encontrado");
                }
                var livrosDaLista = _listaLivrosRepositorio.BuscaListaPorLivro(id);
                if (livrosDaLista.Count > 0)
                {
                    return BadRequest($"Livro com o id {id} está sendo utilizado em alguma lista de leitura. Não foi possível realizar a exclusão.");
                }
                _livroRepositorio.ExcluirLivro(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Livro excluído com sucesso");
        }

    }
}
