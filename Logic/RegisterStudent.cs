using DataAccess.Models;
using DataAccess.Dapper;

namespace Logic
{
    public class RegisterStudent
    {
        public string RegisterUser(string voornaam, string achternaam, string geslacht,string password,string username,string email,int selectedCategory)
        {
            
            var userAccess = new UserRepository();

            var userExists = userAccess.GetUserByUsername(voornaam + "-" + achternaam);

            if(userExists is true)
            {
                return  "User already exists.";
            }
            else
            {
                var newUser = new User()
                {
                    Username = username,
                    IsManager = false,
                    Firstname = voornaam,
                    Lastname = achternaam,
                    Sex = geslacht,
                    Password = password,
                    Email = email,
                    CategoryId = selectedCategory
                };

                var result = userAccess.CreateUser(newUser);
                if (result is true)
                {
                    return "User created";
                }

                return "Unable to create user";
            }
           
        }    
    }

}
