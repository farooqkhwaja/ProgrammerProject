using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DataAccessServices
    {
        public string RegisterUser(string voornaam, string achternaam, string geslacht )
        {
            
            UserRepository userAccess = new UserRepository();
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
                Password = voornaam + "-" + achternaam
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
