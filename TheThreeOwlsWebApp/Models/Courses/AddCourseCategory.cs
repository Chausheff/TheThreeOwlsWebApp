namespace TheThreeOwlsWebApp.Models.Courses
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddCourseCategory
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = CourseCategoryMinLength)]
        public string Language { get; set; }
    }
}
