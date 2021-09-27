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

        public IEnumerable<CourseListingViewModel> Courses(string modifier)
        {
            switch (modifier)
            {
                case "ForKids":
                    return ForKidsFilter(true);
                case "elders":
                    return ForKidsFilter(false);
                case "Sugestopedy":
                    return Sugestopedy();
                case "All":
                    return All();
                default:
                    break;
            }

            var courses = this.data.Courses
            .Where(c =>c.Category.Language == modifier)
            .Select(c => new CourseListingViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ForKids = c.ForKids,
                Sugestopedy = c.Sugestopedy,
                Price = c.Price,
                Image = c.Image,
                Category = c.Category.Language,
                Position = c.Position
            })
            .ToList();

            return courses;

            IEnumerable<CourseListingViewModel> All()
            {
                var courses = this.data.Courses
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Sugestopedy = c.Sugestopedy,
                    Price = c.Price,
                    Image = c.Image,
                    Category = c.Category.Language,
                    Position = c.Position
                })
                .ToList();

                return courses;
            }

            IEnumerable<CourseListingViewModel> ForKidsFilter(bool forKids)
            {
                var courses = this.data.Courses
                .Where(c => c.ForKids == forKids)
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Sugestopedy = c.Sugestopedy,
                    Price = c.Price,
                    Image = c.Image,
                    Category = c.Category.Language,
                    Position = c.Position
                })
                .ToList();

                return courses;
            }

            IEnumerable<CourseListingViewModel> Sugestopedy()
            {
                var courses = this.data.Courses
                .Where(c => c.Sugestopedy == true)
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Sugestopedy = c.Sugestopedy,
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
                Sugestopedy = c.Sugestopedy,
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