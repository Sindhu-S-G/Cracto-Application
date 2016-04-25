using Doctors_Information_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctors_Information_System.Controllers
{
    public class ServerSideCheckController : Controller
    {
        [HttpPost]
        public string CheckEmail(string EmailId)
        {
            var dbc = new DbConnectivityModel();
            bool result = dbc.ValidateEmail(EmailId);
            if(result == true)
            {
                string value = " ";
                return value;
            }
            else 
            {
                string value = "Email Id Already Registered ";
                return value;
            }
        }
    }
}