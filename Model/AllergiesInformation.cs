using System.ComponentModel.DataAnnotations;

namespace IntakeForm.Models
{
    public class AllergiesInformation
    {
        public string Trigger { get; set; }
        public string Severity { get; set; }
        public string Reaction { get; set; }
    }
}
