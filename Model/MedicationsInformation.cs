using System.ComponentModel.DataAnnotations;

namespace IntakeForm.Models
{
    public class MedicationsInformation
    {
        
        public string Medications { get; set; }
        
        public string Frequency { get; set; }
        
        public string Route { get; set; }
    }
}
