﻿namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}