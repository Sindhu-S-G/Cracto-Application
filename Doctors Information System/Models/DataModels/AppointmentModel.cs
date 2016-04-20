using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get;set;}
        public int PatientId { get; set;}
        public int DoctorId { get; set;}
        public string Time {get; set;}
        public string Date { get; set;}
        public bool RowStatus { get; set; } 
    }
}