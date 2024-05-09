using DataAccess.Models;
using DataAccess.ADO;

namespace Logic
{
    public class RegisterStudent
    {
        public string RegisterUser(string voornaam, string achternaam, string geslacht,string password,string username, string leraar, int categorieId)
        {
            
            UserRepository userAccess = new UserRepository();

            var userExists = userAccess.GetUserByUsername(voornaam + "-" + achternaam);

            if(userExists is true)
            {
                return  "User already exists.";
            }
            else
            {

                //var categorieName = category.Id;
                var newUser = new User()
                {
                    Username = username,
                    IsManager = false,
                    FirstName = voornaam,
                    LastName = achternaam,
                    Sex = geslacht,
                    //Password = password,
                    //Leraar = leraar,
                    //FK_UploadDanceFigures = categorieId,
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
