using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        
        [Required]
        public Customer Customer { get; set; }
        
        [Required]
        public Movie Movie { get; set; }
        
        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
