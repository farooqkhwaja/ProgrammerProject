using DataAccess.Models;
using DataAccess.ADO;
using System.ComponentModel;

namespace Logic
{
    public class DataAccessServices
    {
        public string RegisterUser(string voornaam, string achternaam, string geslacht, string password )
        {
            
            UserAccess userAccess = new UserAccess();
            var userExists = userAccess.GetUserByUsername(voornaam + "-" + achternaam);

            if(userExists is true)
            {
                return  "User already exists.";
            }

            var newUser = new User()
            {
                Username = voornaam,
                IsManager = false,
                FirstName = voornaam,
                LastName = achternaam,
                Sex = geslacht,
                Password = password,
            };
            
            var result = userAccess.CreateUser(newUser);
            if(result is true)
            {
                return "User created";
            }

            return "Unable to create user";
        }    
    }

}
