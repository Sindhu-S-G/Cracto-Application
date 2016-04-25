using Doctors_Information_System.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctors_Information_System.Controllers
{
    public class ProfileController : Controller
    {
        const string PatientRole = "1";
        // GET: Profile
        public ActionResult SearchLayout()
        {
            if (Session["UserId"] != null && Session["Role"].ToString() == PatientRole)
           {
                var dbc = new DbConnectivityModel();
                var searchModel = new SearchFilterModels
                {
                    CityName = dbc.ListOutCities(),
                    SpecializationList = dbc.ListOutSpecialization()
                };
                return View(searchModel);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult SearchResult()
        {
            if (Session["UserId"] != null /*&& Session["Role"].ToString() == PatientRole*/)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
       
        public ActionResult ChangePassword()
        {
            if (Session["UserId"] != null /*&& Session["Role"].ToString() == PatientRole*/)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(string CurrentPassword, string NewPassword)
        {
            var dbc = new DbConnectivityModel();
            var userId = Session["UserId"].ToString();
            bool exist = dbc.CheckPassword(CurrentPassword,userId);
            if(exist == true)
            {
                bool change = dbc.UpdatePassword(CurrentPassword,NewPassword, userId);
                if (change == true)
                {
                    return View("Account");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.PasswordMessage = "Invalid Password";
                return View();
            }
        }

        public ActionResult Account()
        {
            if (Session["UserId"] != null && Session["Role"].ToString() == PatientRole)
            {
                var dbc = new DbConnectivityModel();
                var userModel = new UserRegistrationDetail
                {
                    CityName = dbc.ListOutCities(),
                    State = dbc.ListOutStates()
                };
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }  
        }

         [HttpPost]
        public ActionResult UdateAccount(string FullName, string PhoneNumber, DateTime DateOfBirth,string Gender,string BloodGroup)
         {
             var dbc = new DbConnectivityModel();
             //var outcome = dbc.InsertLocality(Locality);
             var userId = Session["UserId"].ToString();
             var result = dbc.UpdateAccountDetails(FullName, PhoneNumber,DateOfBirth,Gender,BloodGroup, userId);
             return RedirectToAction("Account");
         }

        public JsonResult GetDetails()
        {
            var dbc = new DbConnectivityModel();
            var UserId = Session["UserId"].ToString();
            var details = dbc.AccountDetails(UserId);
            return Json(details, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCities(int StateId)
        {
            var dbc = new DbConnectivityModel();
            var CitiesList = dbc.ListingCities(StateId);
            return Json (CitiesList,JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public ActionResult ChangeEmail(ChangeEmail change)
        {
            var dbc = new DbConnectivityModel();
            change.EmailId = Request["EmailId"];
            change.Password = Request["Password"];
            var userId = Session["UserId"].ToString();
            bool result = dbc.ValidateEmail(change.EmailId);
            if (result == true)
            {
                bool exist = dbc.CheckPassword(change.Password, userId);
                if (exist == true)
                {
                    bool outcome = dbc.ChangeEmailId(change.EmailId, change.Password, userId);
                    if (outcome == true)
                    {
                        return RedirectToAction("Account");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ViewBag.PasswordMessage = "Invalid Password";
                    return View();
                }
            }
            else
            {
                ViewBag.EmailMessage = "Email ID already Registered";
                return View();
            }
        }

        public ActionResult ChangeEmail()
        {
            if (Session["UserId"] != null /*&& Session["Role"].ToString() == PatientRole*/)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Feedback()
        {
            if (Session["UserId"] != null /*&& Session["Role"].ToString() == PatientRole*/)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult AppointmentList()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("SearchLayout");
        }/*Logging Out*/
    }
}