using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    public static class AuthenticationHelper
    {
        public static String UserName { get; private set; } 

        #region Static Methods

        public static bool IsValidUsernamePassword(string username, string password)
        {
            // return false if either value is invalid
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // try to get userID from username string
            string getUserIDQuery =
                $@"SELECT AgentID FROM Agent WHERE UserName = '{username}';";

            // execute query and catch result as an int.

            int? userID = DataAccess.ExecuteScalar(getUserIDQuery) as int?;

            // if userID is null, no username matching parameter username was found
            if(userID == null)
            {
                return false;
            }

            // get password from database
            // construct sql query using userID
            string sqlPasswordQuery =
                $@"SELECT Password FROM Password WHERE AgentID = {userID.Value}";
            // execute query and save result to a string
            string sqlPassword = DataAccess.ExecuteScalar(sqlPasswordQuery).ToString();

            // if password from sql does not match password from parameter, return false
            if(sqlPassword != password)
            {
                return false;
            }

            // otherwise sqlPassword must match password, therefore its true

            UserName = username;

            return true;
        }

        #endregion
    }
}
