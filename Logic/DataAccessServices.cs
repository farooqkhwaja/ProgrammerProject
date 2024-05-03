using DataAccess.Models;
using DataAccess.ADO;

namespace Logic
{
    public class DataAccessServices
    {
        public string RegisterUser(string voornaam, string achternaam, string geslacht,string password,string username, string leraar, UploadDanceFigures uploadDanceFigures )
        {
            
            UserRepository userAccess = new UserRepository();

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
                    FirstName = voornaam,
                    LastName = achternaam,
                    Sex = geslacht,
                    Password = password,
                    Leraar = leraar,
                    FK_UploadDanceFigures = uploadDanceFigures.Id,
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
