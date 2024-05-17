using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Links
{
    [Key]
    public int Id { get; set; }
        
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
        
    [Required] 
    public string url {  get; set; }

    [Required]
    public int CreatedBy { get; set; }
        
    [Required]
    public int DanceCategoryId { get; set; }
}
