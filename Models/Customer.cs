using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        public MembershipTypes? MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}
