using Doctors_Information_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctors_Information_System.Controllers
{
    public class DoctorsProfileController : Controller
    {
        const string DoctorRole = "2";
        // GET: DoctorsProfile
        public ActionResult SearchLayout()
        {
            //if (Session["EmailId"] != null)
           // {
                var dbc = new DbConnectivityModel();
                var searchModel = new SearchFilterModels
                {
                    CityName = dbc.ListOutCities(),
                    SpecializationList = dbc.ListOutSpecialization()
                };
                return View(searchModel);
            //}
           // else
           //{
                //return RedirectToAction("Login", "Home");
           // } 
        }

        public JsonResult ListCities(int StateId)
        {
            var dbc = new DbConnectivityModel();
            var CitiesList = dbc.ListingCities(StateId);
            return Json(CitiesList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchResult()
        {
            //if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
           // {
                return View();
           // }
           // else
           // {
            //    return RedirectToAction("Login", "Home");
            //}
        }

        public ActionResult Account()
        {
            if (Session["UserId"] != null /*&& Session["Role"] == DoctorRole*/)
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
        public ActionResult UdateAccount(string FullName, string PhoneNumber, DateTime DateOfBirth, string Gender, string BloodGroup)
        {
            var dbc = new DbConnectivityModel();
            //var outcome = dbc.InsertLocality(Locality);
            var userId = Session["UserId"].ToString();
            var result = dbc.UpdateAccountDetails(FullName, PhoneNumber, DateOfBirth, Gender, BloodGroup, userId);
            return RedirectToAction("Account");
        }

        public JsonResult GetDetails()
        {
            var dbc = new DbConnectivityModel();
            var UserId = Session["UserId"].ToString();
            var details = dbc.AccountDetails(UserId);
            return Json(details, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangePassword()
        {
            //if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
            //{
                return View();
           // }
           // else
           // {
              //  return RedirectToAction("Login", "Home");
            //}
        }

        [HttpPost]
        public ActionResult ChangeUserPassword(string CurrentPassword, string NewPassword)
        {
            var dbc = new DbConnectivityModel();
            var userId = Session["UserId"].ToString();
            bool exist = dbc.CheckPassword(CurrentPassword, userId);
            if (exist == true)
            {
                bool change = dbc.UpdatePassword(CurrentPassword, NewPassword, userId);
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

        public ActionResult ChangeEmail()
        {
           // if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
           // {
                return View();
           // }
           // else
           // {
               // return RedirectToAction("Login", "Home");
            //}
        }

        [HttpPost]
        public ActionResult ChangeEmailId(string EmailId, string Password)
        {
            var dbc = new DbConnectivityModel();
            var userId = Session["UserId"].ToString();
            bool result = dbc.ValidateEmail(EmailId);
            if (result == true)
            {
                bool exist = dbc.CheckPassword(Password, userId);
                if (exist == true)
                {
                    bool outcome = dbc.ChangeEmailId(EmailId, Password, userId);
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

        public ActionResult EditProfilePage()
        {
            //if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
            //{
                var dbc = new DbConnectivityModel();
                ViewBag.SpecializationList = dbc.ListOutSpecialization().ToList();
                return View();
           // }
           // else
           // {
              //  return RedirectToAction("Login", "Home");
            //}
            
        }
        public ActionResult TimeSetting()
        {
            //if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
           // {
                return View();
            //}
           // else
           // {
           //     return RedirectToAction("Login", "Home");
            //}
        }
        public ActionResult Feedback()
        {
           // if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
           // {
                return View();
           // }
           // else
           // {
            //    return RedirectToAction("Login", "Home");
            //}
        }
        public ActionResult Appointment()
        {
           // if (Session["EmailId"] != null /*&& Session["Role"] == DoctorRole*/)
           // {
                return View();
            //}
            //else
           // {
           //     return RedirectToAction("Login", "Home");
           // }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login","Home");
        }/*Logging out*/
    }
}
