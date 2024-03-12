namespace DataAccess.Models;

public class User
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool IsManager { get; set; } = false;
}
