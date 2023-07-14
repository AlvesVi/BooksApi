using System.ComponentModel.DataAnnotations;

namespace BooksApi.Model
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo Título é obrigatório")]
        [MaxLength (50, ErrorMessage = "O campo Título deve conter no máximo 50 caracteres.")]
        [MinLength (4, ErrorMessage = "O campo Título deve conter no mínomo 4 caracteres")]
        public required string Titulo { get; set; }
        public int GeneroId { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }

        public Livro()
        {
            Autor = string.Empty;
        }



    } 
}
