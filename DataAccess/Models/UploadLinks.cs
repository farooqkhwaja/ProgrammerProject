namespace DataAccess.Models
{
    public class UploadLinks
    {
        public int Id { get; set; } 
        public string Link { get; set; }    
        public ICollection<Managers> managers { get; set; }
    }
}
