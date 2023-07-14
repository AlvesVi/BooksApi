using BooksApi.Database;
using BooksApi.Model;
using BooksApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repositories
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private BookContext _banco;

        public LivroRepositorio(BookContext banco)
        {
            _banco = banco;
        }
        public List<Livro> ListaLivro()
        {
            return _banco.Livros.ToList();
        }
        public Livro BuscarPorId(int id)
        {
            return _banco.Livros.Find(id);
        }

        public List <Livro> BuscarPorTitulo(string titulo)
        {
            return _banco.Livros.Where(x => x.Titulo.Contains(titulo)).ToList();
        }        

        public List<Livro> BuscarPorGeneroId(int generoid)
        {
            return _banco.Livros.Where(x => x.GeneroId == generoid).ToList();
        }
        public Livro CadastrarLivro(Livro livro)
        {
            _banco.Livros.Add(livro);
            _banco.SaveChanges();
            return livro;
        }
     
        public Livro AlterarLivro(Livro livro)
        {
            _banco.Livros.Update(livro);
            _banco.SaveChanges();
            return livro;
        }
     
        public void ExcluirLivro(int id)
        {
            var livro = BuscarPorId(id);
            if (livro != null)
            {
                _banco.Livros.Remove(livro);
                _banco.SaveChanges();
            }

        }

    }
}
