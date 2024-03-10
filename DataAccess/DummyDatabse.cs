using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DummyDatabse
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public DummyDatabse(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public List<DummyDatabse> LoginData { get; private set; } = new List<DummyDatabse>()
        {
            new DummyDatabse("Farooq","123456"),
            new DummyDatabse("Larry","123"),
            new DummyDatabse("Dimi" ,"654321"),
        };      
    }
}
