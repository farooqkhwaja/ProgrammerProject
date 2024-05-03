namespace DataAccess.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Username { get; set; }
    public  string Password { get; set; }
    public bool IsManager { get; set; }
    public string Email { get; set; }
    public string Leraar { get; set; }
    public Attendance attendance { get; set; }
    public ICollection<Managers>managers { get; set; }
    public int FK_UploadDanceFigures {  get; set; }
    public UploadDanceFigures UploadDanceFigures { get; set; }
}
