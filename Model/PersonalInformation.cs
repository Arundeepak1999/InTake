using System;
using System.ComponentModel.DataAnnotations;

namespace IntakeForm.Models
{
    public class PersonalInformation
    {
        
        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string Suffix { get; set; }

        public string SSN { get; set; }
        
        public DateTime DateofBirth { get; set; }
        
        public string BirthSex { get; set; }
    }
}
