using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class DoctorsProfileModel
    {
        public string Fullname { get; set; }
        public string Qualification { get; set; }
        public IEnumerable<SpecializationModels> SpecializationList { get; set; }
        public int Experience { get; set; }
        public string LocationName { get; set; }
        public IEnumerable<CityDetailsModels> CityName { get; set; }
        public string Timing { get; set; }
        public string Weekdays { get; set; }
        public int RecommendationNumber { get; set; }
        public int FeedbackNumber { get; set; }
    }
}