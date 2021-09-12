namespace TheThreeOwlsWebApp.Models.Courses
{
    using System;
    public class CourseListingViewModel
    {
        public string Id { get; init; } 

        public string Name { get; init; }

        public string Description { get; set; }

        public bool ForKids { get; set; } = false;

        public bool Sugestopedy { get; set; } 

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }

        public int Position { get; set; }
    }
}
