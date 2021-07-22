using System;
namespace TheThreeOwlsWebApp.Models.Courses
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.DataConstants;
    public class AddCourseViewModel
    {
        [Required]
        [MaxLength(CourseNameMaxLength)]
        public string Name { get; init; }

        public string TeacherId { get; set; }

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
    }
}
