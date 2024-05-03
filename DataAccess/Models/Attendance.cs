using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public ICollection<User>users { get; set; }
        public DateTime Datum { get; set; }
    }
}
