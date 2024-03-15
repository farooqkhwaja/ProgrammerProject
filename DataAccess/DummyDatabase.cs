using DataAccess.Models;

namespace DataAccess
{
    public class DummyDatabase
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>()
            {
                new User() { Username = "John", Password = "111", IsManager = true },
                new User() { Username = "Mechenko", Password = "222", IsManager = false },
                new User() { Username = "Khwaja", Password = "333", IsManager = false },
                new User() { Username = "Delalamon", Password = "333", IsManager = true },
            };

            return users;
        }
    }
}
