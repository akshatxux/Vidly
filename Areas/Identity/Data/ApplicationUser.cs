using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Areas.Identity.Data

{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
