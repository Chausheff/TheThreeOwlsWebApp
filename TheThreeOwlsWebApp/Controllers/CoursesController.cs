﻿namespace TheThreeOwlsWebApp.Controllers
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

        public IActionResult All()
        {
            var courses = this.data.Courses
                 .Select(c => new CourseListingViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Description = c.Description,
                     ForKids = c.ForKids,
                     Price = c.Price,
                     Image = c.Image,
                     Languige = c.Languige,
                     Position = c.Position
                 })
                 .ToList();

            return View(courses);
        }
        public IActionResult Details(string Id)
        {
            var course = this.data.Courses
                .Where(c => c.Id == Id)
                 .Select(c => new CourseListingViewModel
                 {
                     Name = c.Name,
                     Description = c.Description,
                     ForKids = c.ForKids,
                     Price = c.Price,
                     Image = c.Image,
                     Languige = c.Languige
                 })
                 .FirstOrDefault();
            if (course != null)
            {
                return View(course);
            }

            return NotFound();
        }
        public IActionResult Add() => View();
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
                    Languige = c.Languige,
                    Image = c.Image,
                    Price = c.Price,
                    Position = c.Position
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
                ForKids = course.ForKids,
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
        public IActionResult Edit(CourseListingViewModel course)
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
            editedCourse.ForKids = course.ForKids;
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