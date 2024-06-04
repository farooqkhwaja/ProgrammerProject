using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [ForeignKey("CreatedBy")]
    public int CreatedBy { get; set; }
    public string Firstname {  get; set; }
        
    [Required]
    [ForeignKey("DanceCategoryId")]
    public int DanceCategoryId { get; set; }
    public string CategoryName {  get; set; }  
}
