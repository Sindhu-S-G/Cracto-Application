using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class OtpVerification
    {
        public string UserId { get; set; }
        public string OtpVerificationCode { get; set; }
    }
}