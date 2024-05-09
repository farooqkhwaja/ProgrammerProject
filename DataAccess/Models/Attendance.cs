using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool Absent { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
