using DataAccess.Models;
using DataAccess.ADO;

namespace Logic
{
    public class GeneratePartners
    {
        private readonly UserRepository _userRepository;
        public GeneratePartners()
        {
            _userRepository = new UserRepository();
        }

        public User GetRandomUser()
        {
            var users = _userRepository.GetFirstnames();

            Random random = new Random();
            var randomIndex = random.Next(1, users.Count);
            User randomUser = users[randomIndex];

            return randomUser;
        }
    }
}
