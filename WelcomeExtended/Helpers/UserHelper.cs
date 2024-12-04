using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static string ToString(this User user)
        {
            string facultyNumString = string.Empty;

            if(user.FacultyNumber != null && user.FacultyNumber != "")
            {
                facultyNumString = user.FacultyNumber;
            }

            return $"Name: {user.Name}, Role: {user.Role}, Faculty number: {facultyNumString}, Email: {user.Email}";
        }

        public static bool ValidateCredentials(this UserData userData, string name, string password, out string errMessage)
        {
            if (name == null || name == "")
            {
                errMessage = "The Name field cannot be empty!";
                return false;
            }
            
            if(password == null || password == "")
            {
                errMessage = "The Password field cannot be empty!";
                return false;
            }

            if(userData.ValidateUser(name, password)) {
                errMessage = "";
                return true;
            }

            errMessage = "An user with these credentials was not found!";
            return false;
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.getUser(name, password);
        }
    }
}
