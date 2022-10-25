using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace IntakeForm.Models
{
    public class ContactInformation
    {
    
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
