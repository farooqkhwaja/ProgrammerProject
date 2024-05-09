namespace DataAccess.Models
{
    public class Managers
    {
        public int Id { get; set; }
        public int Fk_Users { get; set; }
        public int Fk_UploadLinks { get; set; }
        public int Fk_UploadEvents { get; set; }
        public User user { get; set; }
        public UploadLinks links { get; set; }
        public UploadEvents uploadEvents { get; set; }

    }
}
