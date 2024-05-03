using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Categorie
    {   
        public int Id { get; set; }
        public string CategorieName { get; set; }   
        public ICollection<User> Users { get; set; }
    }
}
