using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genres
    {
        public byte Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
