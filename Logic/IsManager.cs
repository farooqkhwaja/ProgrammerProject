using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class IsManager
    {
        private string _username;
        private string _password;
        private static List<IsManager> managers = new List<IsManager>()
        {
             new IsManager("farooq", "123456"),
             new IsManager("dimi", "12345"),
        };


        public IsManager(string username, string password)
        {
            this._username = username;
            this._password = password;
            managers.Add(this);
        }
        public static bool Ismanager(string username, string password)
        {
            foreach( var manager in managers) 
            {
                if(manager._username == username && manager._password == password)
                {
                    return true;
                }                                 
            }
            return false;
        }
    }
}
