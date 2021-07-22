namespace TheThreeOwlsWebApp.Controllers
{
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

        public IActionResult All(string forKids)
        {
            var kidsCourse = false;
            if (forKids == "true")
            {
                kidsCourse = true;
            }

            var courses = this.data.Courses
                .Where(c => c.ForKids == kidsCourse)
                 .Select(c => new CourseListingViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Description = c.Description,
                     ForKids = c.ForKids,
                     StartDate = c.StartDate,
                     EndDate = c.EndDate,
                     Price = c.Price,
                     Image = c.Image,
                     Languige = c.Languige
                 })
                 .ToList();

            return View(courses);
        }
        public IActionResult Add() => View();
        public IActionResult Details(string id)
        {
            var course = data.Courses
                .Where(c =>c.Id == id)
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ForKids = c.ForKids,
                    Languige = c.Languige,
                    Image = c.Image,
                    Price = c.Price
                })
                .FirstOrDefault();
            return View(course);
        }

        [HttpPost]
        public IActionResult Add(AddCourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            var newCourse = new Course
            {
                Name = course.Name,
                TeacherId = course.TeacherId,
                ForKids = course.ForKids,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Price = course.Price,
                Image = course.Image,
                Description = course.Description,
                Languige = course.Languige
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            return RedirectToAction("All", "Courses");
        }
        [HttpPost]
        public IActionResult Details(CourseListingViewModel course)
        {
            var editedCourse = data.Courses
                .FirstOrDefault(c => c.Id == course.Id);

            if (editedCourse ==null)
            {
                return NotFound();
            }

            editedCourse.Image = course.Image;
            editedCourse.Languige = course.Languige;
            editedCourse.Name = course.Name;
            editedCourse.Price = course.Price;
            editedCourse.StartDate = course.StartDate;
            editedCourse.ForKids = course.ForKids;
            editedCourse.EndDate = course.EndDate;
            editedCourse.Description = course.Description;

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