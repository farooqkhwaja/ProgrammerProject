using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        [ForeignKey("DanceCategoryId")]
        public int DanceCategoryId {  get; set; }
        public string CategoryName { get; set; }
        [Required]
        [ForeignKey("LocationId")]
        public int LocationId {  get; set; }
        public string StreetName { get; set; }
        public string Fulllocation {  get; set; }



    }
}
