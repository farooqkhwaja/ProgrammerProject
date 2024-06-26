﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
