using DataAccess.ADO;

namespace DataAccess.Models
{
    public class UploadLinks
    {
        public int Id { get; set; } 
        public string FigureName {  get; set; }
        public string LinkAdres { get; set; }    
        public ICollection<Managers> managers { get; set; }
        public int FK_UploadDanceFigures { get; set; }
        public UploadDanceFigures uploaddancefigures {  get; set; }
        public string GemaaktDoor {  get; set; }
    }
}
