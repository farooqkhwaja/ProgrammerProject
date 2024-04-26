using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UploadDanceFigures
    {
        public int Id { get; set; }
        public string FigureName {  get; set; }
        public bool Progress { get; set; } = false;
    }
}
