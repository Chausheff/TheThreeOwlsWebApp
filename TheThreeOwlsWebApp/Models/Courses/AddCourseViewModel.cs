namespace TheThreeOwlsWebApp.Models.Courses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.DataConstants;
    public class AddCourseViewModel
    {
        public string Id { get; init; }

        [Required]
        [MaxLength(CourseNameMaxLength)]
        public string Name { get; init; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool ForKids { get; set; } = false;

        [Required]
        public bool Suggestopedia { get; set; } = false;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        [Required]
        public string CategoryId { get; set; }
        public AddCourseCategory Category{ get; set; }

        public IList<ListCourseCategories> Categories { get; set; }

        public int Position { get; set; }
    }
}
