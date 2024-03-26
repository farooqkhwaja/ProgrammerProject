using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UploadLinks
    {
        public int Id { get; set; } = null
        public string Link { get; set; }    
        public ICollection<Managers> managers { get; set; }
    }
}
