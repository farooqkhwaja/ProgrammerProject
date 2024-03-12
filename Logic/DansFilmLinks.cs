using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DansFilmLinks
    {
        public DansFilmLinks(int id, string figureName, string links)
        {
            Id = id;
            FigureName = figureName;
            Links = links;
        }

        int Id {  get; set; }
        string FigureName { get; set; }
        string Links {  get; set; }

        
    }
}
