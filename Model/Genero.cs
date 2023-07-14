using System.ComponentModel.DataAnnotations;

namespace BooksApi.Model
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength (50, ErrorMessage = "O campo descrição deve conter no máximo 50 caracteres")]
        [MinLength (4, ErrorMessage = "O campo descrição deve conter no mínimo 4 caracteres")]
        public required string Descricao { get; set; }
    }
}
