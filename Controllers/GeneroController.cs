using BooksApi.Model;
using BooksApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : Controller
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly ILivroRepositorio  _livroRepositorio;

        public GeneroController(IGeneroRepositorio generoRepositorio, ILivroRepositorio livroRepositorio)
        {
            _generoRepositorio = generoRepositorio;
            _livroRepositorio = livroRepositorio;

        }
        /// <summary>
        /// Lista todos os gêneros cadastrados no sistema
        /// </summary>
        /// <returns code="200"></returns>
        [HttpGet ("/api/ListarTodosOsGeneros")]
        public IActionResult ListarTodosOsGeneros()
        {
            var generos = _generoRepositorio.ListaGeneros();
            return Ok(generos);
        }

        /// <summary>
        /// Realiza a busca de um gênero pelo ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("/api/BuscaPorIdGenero/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var genero = _generoRepositorio.BuscarPorId(id);
            return genero == null ? BadRequest($"Genero com o id {id} não encontrado") : Ok(genero);
        }

        /// <summary>
        /// Realiza a busca de um gênero pela Descrição informada
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [HttpGet ("/api/BuscarPorDescricao/{descricao}")]
        public IActionResult BuscarPorDescricao(string descricao)
        {
            var genero = _generoRepositorio.BuscarPorDescricao (descricao);
            return genero == null ? BadRequest($"Descrição {descricao} não encontrada") : Ok(genero);
        }

        /// <summary>
        /// Cadastra um novo Gênero
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPost ("/api/CadastrarGenero")]

        public IActionResult CadastrarGenero(Genero genero)
        {
            var buscaGenero = _generoRepositorio.BuscarPorDescricao(genero.Descricao);
            if (buscaGenero != null)
            {
                return BadRequest($"Já existe um gênero cadastrado com a descrição {genero.Descricao}");
            }
            _generoRepositorio.CadastrarGenero(genero);
            return Ok(genero);
        }

        /// <summary>
        /// Alteração das informações de gênero
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut ("/api/AlterarGenero")]
        public IActionResult AlterarGenero(Genero genero)
        {
            _generoRepositorio.AlterarGenero(genero);
            return Ok(genero);
        }


        /// <summary>
        /// Exclusão de gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("/api/ExcluirGenero")]
        public IActionResult ExcluirGenero(int id)
        {
            try
            {
                var genero = _generoRepositorio.BuscarPorId (id);
                if (genero == null)
                {
                    return BadRequest($"Genero com o id {id} não encontrado");
                }
                var livros = _livroRepositorio.BuscarPorGeneroId(id);
                if (livros.Count > 0)
                {
                    return BadRequest("Este Gênero esta sendo utilizado em um Livro.");
                }
                _generoRepositorio.ExcluirGenero(id);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Gênero excluído com sucesso");
        }
    }
}
