namespace DataAccess.Models
{
    public class UploadDanceFigures
    {
        public int Id { get; set; }
        public string FigureName {  get; set; }
        public string CategoryName {  get; set; }
        public bool Progress { get; set; }  
        public ICollection<UploadLinks> uploadlinks { get; set; }
    }
}
