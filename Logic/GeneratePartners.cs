
using DataAccess.ADO;


namespace Logic
{
    public class GeneratePartners
    {

        private readonly UserRepository _userrepository;
        public GeneratePartners()
        {
            _userrepository = new UserRepository();
        }
    }
}
