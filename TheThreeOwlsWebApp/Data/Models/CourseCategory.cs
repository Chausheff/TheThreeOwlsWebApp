namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class CourseCategory
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Language { get; set; }
    }
}
