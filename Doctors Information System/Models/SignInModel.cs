using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class SignInModel
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z]{2,4})+$", ErrorMessage = "Invalid E-mail Id")]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }

    }
}