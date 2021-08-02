﻿namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;
    public class Course
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CourseNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool ForKids { get; set; } = false;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        [Required]
        public string Languige { get; set; }

        public int Position { get; set; }
    }
}
