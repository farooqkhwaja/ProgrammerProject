using DataAccess.ADO;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Links
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        
        public Uri Url {  get; set; }

        [Required]
        public int CreatedBy { get; set; }
    }
}
