﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApp.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [DisplayName("The Price")]
        public decimal? Price { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int categoryId { get; set; }


        public string? imagePath { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

         

        public Category? Category { get; set; }
    }
}
