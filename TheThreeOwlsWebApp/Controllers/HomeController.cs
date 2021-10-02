namespace TheThreeOwlsWebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Linq;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Data.Models;
    using TheThreeOwlsWebApp.Models;
    using TheThreeOwlsWebApp.Models.Courses;
    using TheThreeOwlsWebApp.Models.Home;
    using TheThreeOwlsWebApp.Models.Intro;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ThreeOwlsDbContext data;

        public HomeController(ILogger<HomeController> logger, ThreeOwlsDbContext data)
        {
            this._logger = logger;
            this.data = data;
        }

        public IActionResult Index()
        {
            var comments = this.data.IntroComments
                .Select(c => new CarouselIntroListingModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author,
                    AuthorAge = c.AuthorAge,
                    Picture = c.Picture
                })
                .ToList();

            var courses = this.data.Courses
                .Select(c => new CourseListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Image = c.Image,
                    Position = c.Position
                })
                .OrderBy(c => c.Position)
                .Take(6)
                .ToList();

            var home = new HomeViewModel();
            home.courses = courses;
            home.intros = comments;
            return View(home);
        }

        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Add(CarouselIntroListingModel intro)
        {
            if (!ModelState.IsValid)
            {
                return View(intro);
            }

            if (intro.Picture == null)
            {
                intro.Picture = "/images/LogoFull.jpg";
            }
            var introComment = new IntroComment
            {
                Author = intro.Author,
                AuthorAge = intro.AuthorAge,
                Text = intro.Text,
                Picture = intro.Picture
            };
            this.data.IntroComments.Add(introComment);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var comment = this.data.IntroComments
                .FirstOrDefault(t => t.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            this.data.IntroComments.Remove(comment);
            this.data.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}