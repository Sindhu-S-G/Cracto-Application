using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class UserRegistrationDetail
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets can be entered")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string BloodGroup { get; set; }
        [RegularExpression(@"^[A-Za-z]+$")]
        public string PhoneNumber { get; set; }
        public string Locality { get; set; }
        public IEnumerable<CityDetailsModels> CityName { get; set; }
        public IEnumerable<StateDetailsModels> State { get; set; }
    }
}