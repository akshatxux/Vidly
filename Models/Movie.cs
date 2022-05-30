using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
        
        public Genres? Genre { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}
