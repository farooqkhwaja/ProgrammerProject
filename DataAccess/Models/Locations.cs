namespace DataAccess.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; } 
        public ICollection<UploadEvents> uploadEvents { get; set; }

    }
}
