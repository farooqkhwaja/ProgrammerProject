using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(50)]
    public  string Password { get; set; }
    [Required]
    [MaxLength(50)]
    public string Firstname { get; set; }
    [Required]
    [MaxLength(50)]
    public string Lastname { get; set; }
    [Required]
    [MaxLength(10)]
    public string Sex { get; set; }
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    [Required]
    public bool IsManager { get; set; }
    public ICollection<UserEvent> UserEvents { get; set; }
    public ICollection<UserAttendance> UserAttendances { get; set; }
}
