using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Doctors_Information_System.Models
{
    public class DbConnectivityModel
    {
        SqlConnection Connect = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        public IEnumerable<CityDetailsModels> ListOutCities()
        {
            string query = "SELECT CityId, CityName FROM dbo.CityDetails";
            var result = Connect.Query<CityDetailsModels>(query);
            return result;
        }/*Listing out the cities in home page*/

        public IEnumerable<LocalityDetailsModels>  ListingLocalities( string CityName)
        {
            string query="SELECT LocalityId,LocalityName FROM dbo.LocalityDetails INNER JOIN dbo.CityDetails ON CityDetails.CityId = LocalityDetails.CityId AND CityDetails.CityName = "+"'"+@CityName+"'";
            var result = Connect.Query<LocalityDetailsModels>(query).ToList();
            return result;
        }

        public IEnumerable<CityDetailsModels> ListingCities (int StateId)
        {
            string query = "SELECT CityId,CityName FROM dbo.CityDetails WHERE CityDetails.StateId = " + @StateId ;
            var result = Connect.Query<CityDetailsModels>(query).ToList();
            return result;
        }

        public IEnumerable<LocalityDetailsModels> ListOutLocalities()
        {
            string query = "SELECT LocalityId, LocalityName FROM dbo.LocalityDetails";
            var result = Connect.Query<LocalityDetailsModels>(query);
            return result;
        }/*Listing out the Localities in home page*/

        public IEnumerable<SpecializationModels> ListOutSpecialization()
        {
            string query = "SELECT SpecializationId, SpecializationName FROM dbo.SpecializationDetails";
            var result = Connect.Query<SpecializationModels>(query);
            return result;
        }/*Listing out the Specialization in home page*/

        public IEnumerable<SpecializationModels> ListingSpecialization(string SpecializationId)
        {
            string query = "SELECT SpecializationId, SpecializationName FROM dbo.SpecializationDetails  WHERE SpecializationId = " + SpecializationId;
            var result = Connect.Query<SpecializationModels>(query);
            return result;
        }

        public IEnumerable<StateDetailsModels> ListOutStates()
        {
            string query = "SELECT StateId, StateName FROM dbo.StateDetails";
            var result = Connect.Query<StateDetailsModels>(query);
            return result;
        }/*Listing out the States in Edit Account page*/

        public IEnumerable<CityDetailsModels> SelectCity(string CityName)
        {
            string query = "SELECT CityId FROM dbo.CityDeatils WHERE CityName = " + "'" + @CityName + "'";
            var result = Connect.Query<CityDetailsModels>(query);
            return result.ToList();
        }/*retrieving the list of cities*/

        public IEnumerable<UserRegistrationDetail> AccountDetails(string UserId)
        {
            string query = "SELECT FullName,Gender,DateOfBirth,EmailId,BloodGroup,PhoneNumber FROM dbo.DemoUser WHERE UserId ="+@UserId;
            var result = Connect.Query<UserRegistrationDetail>(query);
            return result;
        }

        public bool RegisterPatientInOtp(string EmailId, string Password)
        {
            try
            {
                string query = "INSERT INTO dbo.DemoUser (EmailId,Password,Role,IsVerified) VALUES (@EmailId,@Password,1,'False')";
                Connect.Execute(query, new { EmailId, Password });
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        } /*Registering of Patients*/

        public bool RegisterDoctorInOtp(string EmailId, string Password)
        {
            try
            {
                string query = "INSERT INTO dbo.DemoUser (EmailId,Password,Role,IsVerified) VALUES (@EmailId,@Password,2,'False')";
                Connect.Execute(query, new { EmailId, Password });
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        } /*Registering of Doctors*/
  
        public bool CheckAuthentication( RegistrationDetailModel lds)
        {
            string query = "SELECT UserId FROM dbo.DemoUser WHERE EmailId = " + "'" + @lds.EmailId + "'" + "AND Password =" + "'" + @lds.Password + "'"; //+" AND IsVerified = 'True'";
            var result = Connect.Query<RegistrationDetailModel>(query);
            if(result.ToList().Count == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }

        }/*Checking the Authentication of user*/

        public int ReturnUserId(string EmailId,string Password)
        {
            try
            {
                Connect.Open();
                SqlCommand query = new SqlCommand("SELECT UserId FROM dbo.DemoUser WHERE EmailId = " + "'" + @EmailId + "'" + " AND Password =" + "'" + @Password + "'", Connect);
                int UserId = Convert.ToInt16(query.ExecuteScalar());
                return UserId;
            }
            catch
            {
                return 0;
            }
            finally
            {
                Connect.Close();
            }
        }

        public bool ValidateEmail(string EmailId)
        {
            string query = "SELECT UserId FROM dbo.DemoUser WHERE EmailId =" + "'" + @EmailId + "'"+ " AND IsVerified = 'True'";
           /* //'';drop db;--*/
            var result = Connect.Query<RegistrationDetailModel>(query);
            if(result.ToList().Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } /*Checking the uniqueness of Email of each user*/

        public int InsertLocality( string Locality)
        {
            Connect.Open();
            SqlCommand command = new SqlCommand("SELECT LocationId FROM dbo.LocationDetails WHERE LocalityName=" + "'" + @Locality + "'", Connect);
            int id = Convert.ToInt16(command.ExecuteScalar());
            if (id == 0)
            {
                string query = "INSERT INTO dbo.Locationdetails (LocalityName) VALUES (@Locality)";
                Connect.Execute(query, new { Locality });
                id = Convert.ToInt16(command.ExecuteScalar());
            }
            return id;
        }

        public bool UpdateAccountDetails(string FullName, string PhoneNumber,DateTime DateOfBirth,string Gender, string BloodGroup, string UserId)
        {
            try
            {
                string query = "UPDATE dbo.DemoUser SET FullName = " + "'" + @FullName + "'" + ", DateOfBirth = " + "'" + @DateOfBirth + "'" + ", PhoneNumber = " + "'" + @PhoneNumber + "'" + ", Gender =" + "'" + @Gender + "'" + ",  BloodGroup ="+"'"+@BloodGroup+"'"+ " WHERE UserId = " + @UserId;
                Connect.Execute(query, new { FullName, DateOfBirth, PhoneNumber, Gender, BloodGroup });
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool ChangeEmailId(string EmailId,string Password,string UserId)
        {
            try
            {
                string query = "UPDATE dbo.DemoUser SET EmailId = " + "'" + @EmailId + "'" + " WHERE UserId = " + @UserId;
                Connect.Execute(query, new { EmailId });
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool CheckPassword(string Password,string UserId)
        {
            string query = "SELECT UserId FROM dbo.DemoUser WHERE Password =" + "'" + @Password+"'"+" AND UserId="+@UserId;
            var result = Connect.Query<ChangeEmail>(query);
            if(result.ToList().Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdatePassword(string CurrentPassword,string NewPassword,string UserId)
        {
            try
            {
                string query = "UPDATE dbo.DemoUser SET Password = " + "'" + @NewPassword + "'" + " WHERE Password =" + "'" + @CurrentPassword + "'" + " AND UserId =" + @UserId;
                Connect.Execute(query, new { CurrentPassword, NewPassword, UserId });
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        /*public bool EnterInOtp(OtpVerification ovm)
        {
            try
            {
                string query = "INSERT INTO dbo.DemoOtp (UserId,Password,Role,RowStatus) VALUES (@UserEmail,@Password,1,True)";
                Connect.Query<OtpVerification>(query);
            }
            catch(Exception )
            {
                return false;
            }
            return true;

        }8?/*checking the otp send to the user(Not Done)*/

        public int ReturnRole(string EmailId, string Password)
        {
            try
            {
                Connect.Open();
                SqlCommand query = new SqlCommand("SELECT Role FROM dbo.DemoUser WHERE EmailId = " + "'" + @EmailId + "'", Connect);
                int role = Convert.ToInt16(query.ExecuteScalar());
                return role;
            }
            catch
            {
                return 0;
            }
            finally
            {
                Connect.Close();
            }
        }/*returns the role of the user*/

        /*Edit Account page functionality*/

    }
}