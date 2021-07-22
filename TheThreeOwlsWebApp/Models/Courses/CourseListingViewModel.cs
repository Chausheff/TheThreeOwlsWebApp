namespace TheThreeOwlsWebApp.Models.Courses
{
    using System;
    public class CourseListingViewModel
    {
        public string Id { get; init; } 

        public string Name { get; init; }

        public string Description { get; set; }

        public bool ForKids { get; set; } = false;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Languige { get; set; }
    }
}
