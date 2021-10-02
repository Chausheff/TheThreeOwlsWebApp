namespace TheThreeOwlsWebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Teachers;
    using System.Linq;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Data.Models;

    public class TeachersController : Controller
    {
        private readonly ThreeOwlsDbContext data;

        public TeachersController(ThreeOwlsDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var teachers = data.Teachers
                   .Select(t => new TeacherListingViewModel
                   {
                       Id = t.Id,
                       FirstName = t.FirstName,
                       LastName = t.LastName,
                       Picture = t.Picture,
                       Info = t.Info
                   })
                   .ToList();

            return View(teachers);
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        public IActionResult Edit(string id)
        {
            var teacher = this.data.Teachers
              .Where(t => t.Id == id)
              .Select(t => new TeacherListingViewModel
              {
                  Id = t.Id,
                  FirstName = t.FirstName,
                  LastName = t.LastName,
                  Picture = t.Picture,
                  Info = t.Info
              })
             .FirstOrDefault();

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        public IActionResult Details(string Id)
        {
            var teacher = this.data.Teachers
                .Where(t => t.Id == Id)
                .Select(t => new TeacherListingViewModel
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Picture = t.Picture,
                    Info = t.Info
                })
                .FirstOrDefault();

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(TeacherAddingViewModel teacher)
        {
            if (this.data.Teachers.Any(t => t.FirstName == teacher.FirstName && t.LastName == teacher.LastName))
            {
                this.ModelState.AddModelError(nameof(teacher.LastName), "This teacher is already in the database");
            }

            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            var newTeacher = new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Picture = teacher.Picture,
                Info = teacher.Info
            };
            this.data.Teachers.Add(newTeacher);
            this.data.SaveChanges();

            return RedirectToAction("All", "Teachers");
        }

        [Authorize]
        public IActionResult EditTeacher(TeacherListingViewModel teacher)
        {
            var editedTeacher = data.Teachers.FirstOrDefault(t => t.Id == teacher.Id);

            if (editedTeacher == null)
            {
                return NotFound();
            }

            editedTeacher.FirstName = teacher.FirstName;
            editedTeacher.LastName = teacher.LastName;
            editedTeacher.Picture = teacher.Picture;
            editedTeacher.Info = teacher.Info;

            this.data.Teachers.Update(editedTeacher);
            this.data.SaveChanges();

            return RedirectToAction("All", "Teachers");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var removedTeacher = this.data.Teachers
                .FirstOrDefault(t => t.Id == id);

            if (removedTeacher == null)
            {
                return NotFound();
            }

            this.data.Teachers.Remove(removedTeacher);
            this.data.SaveChanges();
            return RedirectToAction("All", "Teachers");
        }
    }
}