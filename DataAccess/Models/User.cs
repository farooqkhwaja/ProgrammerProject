namespace DataAccess.Models;

public class User
{
    public string?FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Sex { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool IsManager { get; set; } = false;
  
}
