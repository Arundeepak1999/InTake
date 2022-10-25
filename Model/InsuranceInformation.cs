using System.ComponentModel.DataAnnotations;

namespace IntakeForm.Models
{
    public class InsuranceInformation
    {
        
        public string InsuranceComapany { get; set; }
        
        public string MemberID { get; set; }
        
        public long GroupNumber { get; set; }
        
        public string PolicyHolder { get; set; }

    }
}
