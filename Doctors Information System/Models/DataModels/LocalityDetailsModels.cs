using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class LocalityDetailsModels
    {
        public int LocalityId {get; set;}
        public string LocalityName {get; set;}
        public int CityId {get; set;}
        public int Zipcode { get; set; }
    }
}