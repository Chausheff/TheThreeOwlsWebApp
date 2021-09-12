namespace TheThreeOwlsWebApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Data.Models;
    using TheThreeOwlsWebApp.Models.Courses;

    public class CoursesController : Controller
    {
        private readonly ThreeOwlsDbContext data;

        public CoursesController(ThreeOwlsDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
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

            return View(courses);
        }

        public IActionResult Study() => View();
        public IActionResult AddCategory() => View();

        public IActionResult Details(string Id)
        {
            var course = this.data.Courses
                .Where(c => c.Id == Id)
                 .Select(c => new CourseListingViewModel
                 {
                     Name = c.Name,
                     Description = c.Description,
                     ForKids = c.ForKids,
                     Sugestopedy = c.Sugestopedy,
                     Price = c.Price,
                     Image = c.Image,
                     Category = c.Category.Language,
                 })
                 .FirstOrDefault();
            if (course != null)
            {
                return View(course);
            }

            return NotFound();
        }

        public IActionResult Add()
        {
            var emptyModel = new AddCourseViewModel();
            var categories = new List<ListCourseCategories>();
            foreach (var ct in this.data.Categories)
            {
                categories.Add(new ListCourseCategories()
                {
                    CourseId = ct.Id,
                    Language = ct.Language
                }) ;
            }

            emptyModel.Categories = categories;
            return View(emptyModel);
        }

        public IActionResult Edit(string id)
        {
            var course = data.Courses
                .Where(c =>c.Id == id)
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ForKids = c.ForKids,
                    Sugestopedy = c.Sugestopedy,
                    Category = c.Category.Language,
                    Image = c.Image,
                    Price = c.Price,
                    Position = c.Position
                })
                .FirstOrDefault();
            return View(course);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCourseCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var newCategory = this.data.Categories.FirstOrDefault(c => c.Language == category.Language);

            if (newCategory == null)
            {
                newCategory = new CourseCategory
                {
                    Language = category.Language
                };
            }

            this.data.Categories.Add(newCategory);
            this.data.SaveChanges();

            return RedirectToAction("All", "Courses");
        }

        [HttpPost]
        public IActionResult Add(AddCourseViewModel course)
        {
            var categories = new List<ListCourseCategories>();
            foreach (var ct in this.data.Categories)
            {
                categories.Add(new ListCourseCategories()
                {
                    CourseId = ct.Id,
                    Language = ct.Language
                });
            }
            course.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            var category = this.data.Categories.FirstOrDefault(l => l.Id == course.CategoryId);

            var newCourse = new Course
            {
                Name = course.Name,
                ForKids = course.ForKids,
                Sugestopedy = course.Sugestopedy,
                Price = course.Price,
                Image = course.Image,
                Description = course.Description,
                Category = category
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            return RedirectToAction("All", "Courses");
        }
        [HttpPost]
        public IActionResult Edit(CourseListingViewModel course)
        {
            var editedCourse = data.Courses
                .FirstOrDefault(c => c.Id == course.Id);

            if (editedCourse ==null)
            {
                return NotFound();
            }

            editedCourse.Image = course.Image;
            editedCourse.Category = this.data.Categories.FirstOrDefault(c => c.Language == course.Category);
            editedCourse.Name = course.Name;
            editedCourse.Price = course.Price;
            editedCourse.ForKids = course.ForKids;
            editedCourse.Sugestopedy= course.Sugestopedy;
            editedCourse.Description = course.Description;
            editedCourse.Position = course.Position;

            this.data.Courses.Update(editedCourse);
            this.data.SaveChanges();

            return RedirectToAction("All", "Courses");
        }

        public IActionResult Delete(string id)
        {
            var removedCourse = this.data.Courses
                .FirstOrDefault(t => t.Id == id);

            if (removedCourse == null)
            {
                return NotFound();
            }

            this.data.Courses.Remove(removedCourse);
            this.data.SaveChanges();
            return RedirectToAction("All", "Courses");
        }
    }
}