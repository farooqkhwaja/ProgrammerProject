using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Location
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string StreetName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string City { get; set; }

    public string Fulllocation => $"{StreetName} {City}";   
    
}

