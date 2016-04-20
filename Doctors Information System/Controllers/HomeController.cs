using Doctors_Information_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctors_Information_System.Controllers
{
    public class HomeController : Controller
    {
        const int PatientRole = 1;
        const int DoctorRole = 2;
        public ActionResult SearchLayout()
        {
            var dbc = new DbConnectivityModel();
            var searchModel = new SearchFilterModels
            {
                CityName = dbc.ListOutCities(),
                SpecializationList = dbc.ListOutSpecialization()
            };
            //ViewBag.CityList = dbc.ListOutCities();
            //ViewBag.SpecializationList = dbc.ListOutSpecialization();
            return View(searchModel);
        }

  
        public JsonResult ListOfLocalities(string CityName)
        {
           var dbc = new DbConnectivityModel();
           var ListOfLocalities = dbc.ListingLocalities(CityName);
           return Json(ListOfLocalities,JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchResult()
        {
            var dbc = new DbConnectivityModel();
            var searchModel = new DoctorsProfileModel
            {
                CityName = dbc.ListOutCities(),
                SpecializationList = dbc.ListOutSpecialization()
            };
            return View(searchModel);
        }/*Retrieves the search result*/

        public ActionResult Login()
        {
            return View();
        }/*To retrieve the Login page*/
        [HttpPost]
        public ActionResult Login(RegistrationDetailModel lds)
        {
            var dbc = new DbConnectivityModel();
            lds.EmailId = Request["UserEmail"];
            lds.Password = Request["Password"];
            bool autheticateUser = dbc.CheckAuthentication(lds);
            if(autheticateUser == true)
            {
                Session["UserId"] = dbc.ReturnUserId(lds.EmailId,lds.Password);                            /*Used Session*/
                int userRole = dbc.ReturnRole(lds.EmailId, lds.Password);
                Session["Role"] = userRole.ToString();
                if(userRole == PatientRole)
                {
                    return RedirectToAction("SearchLayout", "Profile");
                }
                else if (userRole == DoctorRole)
                {
                    return RedirectToAction("SearchLayout", "DoctorsProfile");

                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Invalid Email Id or Password";
                return View();
            }
        }

       
        public ActionResult PatientSignUp()
        {
            
            return View();
        }
        /*To retrieve the patient Signin page*/

        [HttpPost]
        public ActionResult PatientSignUp(string EmailId, string Password)/*To post the patient Sign in page data  (Working) */
        {
                var dbc = new DbConnectivityModel();
                bool result = dbc.ValidateEmail(EmailId);
                if (result == true)
                {
                    bool outcome = dbc.RegisterPatientInOtp(EmailId, Password);
                    if (outcome == true)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Email Already registered";
                    return View();
                }
        }

        public ActionResult DoctorSignUp()
        {
            return View();
        }/*To retrieve the Doctor Signin page*/

        [HttpPost]
        public ActionResult DoctorSignUp(string EmailId, string Password)
        {
           if (ModelState.IsValid)
            {
                var dbc = new DbConnectivityModel();
                bool result = dbc.ValidateEmail(EmailId);
                if (result == true)
                {
                    bool outcome = dbc.RegisterDoctorInOtp(EmailId, Password);
                    if (outcome == true)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Email Already registered";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }  /*To post the daoctors Sign in page data (Working)*/

        public ActionResult OtpVerification()
        {
            return View();
        }/*To retrieve the OTP verification page*/

       /* public ActionResult Signup()
        {
            return View();
        }*//*To post the patient Sign in  data*/


         /*[HttpPost]
        public ActionResult Signup(LoginDetailsModel ldm)
        {
            DbConnectivityModel dbc = new DbConnectivityModel();
            var emailId = Request["EmailId"];
            var password = Request["Password"];
            bool result = dbc.ValidatingEmail(emailId);
            if(result)
            {
                return RedirectToAction("OtpVerification");
            }
            else
            {
                return View();
            }
        }*/
       /* public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("SearchLayout");
        }*/
        
    }
}