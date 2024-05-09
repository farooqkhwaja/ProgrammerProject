
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class DanceCategory
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string CategoryName {  get; set; }

}

