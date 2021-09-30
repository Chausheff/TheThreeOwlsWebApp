namespace TheThreeOwlsWebApp.Services.Courses
{
    using System.Collections.Generic;
    using System.Linq;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Models.Courses;

    public class CourseFilterService : ICourseFilterService
    {
        private readonly ThreeOwlsDbContext data;

        public CourseFilterService(ThreeOwlsDbContext data)
            => this.data = data;

        public IEnumerable<CourseListingViewModel> Courses(string modifier,string lang)
        {
            switch (modifier)
            {
                case "ForKids":
                    return ForKidsFilter(true,lang);
                case "elders":
                    return ForKidsFilter(false,lang);
                case "Suggestopedia":
                    return Suggestopedia();
                case "All":
                    return All(null);
                case "other":
                    return All("other");
                default:
                    break;
            }

            var courses = this.data.Courses
            .Where(c => (lang != null) ? c.Category.Language == lang : true)
            .Select(c => new CourseListingViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ForKids = c.ForKids,
                Suggestopedia = c.Suggestopedia,
                Price = c.Price,
                Image = c.Image,
                Category = c.Category.Language,
                Position = c.Position
            })
            .ToList();

            return courses;

            IEnumerable<CourseListingViewModel> All(string other)
            {
                var courses = this.data.Courses
                .Where(c => (other != null) ? (c.Category.Language == "Математика")||(c.Category.Language == "Литература") : true)
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Suggestopedia = c.Suggestopedia,
                    Price = c.Price,
                    Image = c.Image,
                    Category = c.Category.Language,
                    Position = c.Position
                })
                .ToList();

                return courses;
            }

            IEnumerable<CourseListingViewModel> ForKidsFilter(bool forKids,string lang)
            {
                var courses = this.data.Courses
                .Where(c => c.ForKids == forKids)
                .Where(c => (lang != null) ? c.Category.Language == lang : (c.Category.Language != "Математика" && c.Category.Language != "Литература"))
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Suggestopedia = c.Suggestopedia,
                    Price = c.Price,
                    Image = c.Image,
                    Category = c.Category.Language,
                    Position = c.Position
                })
                .ToList();

                return courses;
            }

            IEnumerable<CourseListingViewModel> Suggestopedia()
            {
                var courses = this.data.Courses
                .Where(c => c.Suggestopedia == true)
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Suggestopedia = c.Suggestopedia,
                    Price = c.Price,
                    Image = c.Image,
                    Category = c.Category.Language,
                    Position = c.Position
                })
                .ToList();

                return courses;
            }
        }

        public CourseListingViewModel TakeCourse(string Id)
        {
            var course = this.data.Courses
            .Where(c => c.Id == Id)
            .Select(c => new CourseListingViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ForKids = c.ForKids,
                Suggestopedia = c.Suggestopedia,
                Price = c.Price,
                Image = c.Image,
                Category = c.Category.Language,
                Position = c.Position
            })
            .FirstOrDefault();

            return course;
        }
    }
}