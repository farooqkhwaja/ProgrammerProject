using System.ComponentModel.DataAnnotations;

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
        public int DanceCategoryId {  get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int LocationId {  get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
    }
}
