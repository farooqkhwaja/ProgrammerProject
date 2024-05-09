﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class DanceFigures
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FigureName {  get; set; }
        public bool Progress { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
