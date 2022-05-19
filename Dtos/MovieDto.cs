using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}
