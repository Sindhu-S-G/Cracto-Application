using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class SearchFilterModels
    {
        
        //public string CityName { get; set; }
        public string Locality { get; set; }
        
        //public string SpecializationName { get; set; }
        [Required(ErrorMessage = "Enter City")]
        public IEnumerable<CityDetailsModels> CityName { get; set; }
        [Required(ErrorMessage = "Enter Specialization")]
        public IEnumerable<SpecializationModels> SpecializationList { get; set; }
    }
}