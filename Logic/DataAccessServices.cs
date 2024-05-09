using DataAccess.Models;
using DataAccess.ADO;
using System.ComponentModel;

namespace Logic
{
    public class DataAccessServices
    {
        private readonly UserRepository _userRepository;
        public string RegisterUser(string voornaam, string achternaam, string geslacht, string password )
        {
            var userExists = _userRepository.GetUserByUsername(voornaam + "-" + achternaam);

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
            
            var result = _userRepository.CreateUser(newUser);
            if(result is true)
            {
                return "User created";
            }

            return "Unable to create user";
        }    
    }

}
