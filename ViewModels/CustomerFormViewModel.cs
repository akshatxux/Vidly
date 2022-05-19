using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipTypes>? MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
