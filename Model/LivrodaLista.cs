using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Model
{
    public class LivrodaLista
    {
        [Key]
        public int Id { get; set; }
        public int LivroId { get; set; }
        public int ListaId { get; set; }
        public bool Lido { get; set; }
    }
}
