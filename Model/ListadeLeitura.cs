using System.ComponentModel.DataAnnotations;

namespace BooksApi.Model
{
    public class ListadeLeitura
    {
        [Key]
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public int QtdeLivros { get; set; }
        public int QtdeLivrosLidos { get; set; }

        public ListadeLeitura()
        {
            QtdeLivros = 0;
            QtdeLivrosLidos = 0;
        }
    }
}
