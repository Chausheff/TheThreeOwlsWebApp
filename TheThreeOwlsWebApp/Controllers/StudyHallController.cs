namespace TheThreeOwlsWebApp.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Models.StudyHall;

    public class StudyHallController : Controller
    {
        private readonly ThreeOwlsDbContext data;

        public StudyHallController(ThreeOwlsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit(string Id)
        {
            var studyHall = data.StudyHalls
                .Where(sh => sh.Id == Id)
                .Select(sh => new StudyHallListingModel
                {
                    Image = sh.Image,
                    Text = sh.Text,
                    Title = sh.Title
                })
                .FirstOrDefault();

            if (studyHall == null)
            {
                return NotFound();
            }

            return View(studyHall);
        }

        public IActionResult Summer()
        {
            var studyHall = data.StudyHalls
                .Where(sh => sh.Educational == false)
                .Select(sh => new StudyHallListingModel
                {
                    Id = sh.Id,
                    Image = sh.Image,
                    Text = sh.Text,
                    Title = sh.Title
                })
                .FirstOrDefault();

            if (studyHall == null)
            {
                studyHall = new StudyHallListingModel
                {
                    Image = "https://prikazka.net/wp-content/uploads/2020/01/images.jpg",
                    Text = "Text placeholder",
                    Title = "Title placeholder"
                };

                var sh = new Data.Models.StudyHall
                {
                    Educational = false,
                    Text = studyHall.Text,
                    Title = studyHall.Title,
                    Image = "https://prikazka.net/wp-content/uploads/2020/01/images.jpg"
                };
                this.data.StudyHalls.Add(sh);
                this.data.SaveChanges();
            }
            return View(studyHall);
        }

        public IActionResult Educational()
        {
            var studyHall = data.StudyHalls
               .Where(sh => sh.Educational == true)
               .Select(sh => new StudyHallListingModel
               {
                   Id = sh.Id,
                   Image = sh.Image,
                   Text = sh.Text,
                   Title = sh.Title
               })
               .FirstOrDefault();

            if (studyHall == null)
            {
                studyHall = new StudyHallListingModel
                {
                    Image = null,
                    Text = "Text placeholder",
                    Title = "Title placeholder"
                };

                var sh = new Data.Models.StudyHall
                {
                    Educational = true,
                    Text = studyHall.Text,
                    Title = studyHall.Title,
                    Image = "https://prikazka.net/wp-content/uploads/2020/01/images.jpg"
                };
                this.data.StudyHalls.Add(sh);
                this.data.SaveChanges();
            }
            return View(studyHall);
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Edit(AddStudyHallModel studyHall)
        {
            if (!ModelState.IsValid)
            {
                return View(studyHall);
            }

            var newStudyHall = data.StudyHalls
                .First(sh => sh.Id == studyHall.Id);

            if (newStudyHall == null)
            {
                return NotFound();
            }

            newStudyHall.Image = studyHall.Image;
            newStudyHall.Title = studyHall.Title;
            newStudyHall.Text = studyHall.Text;

            this.data.StudyHalls.Update(newStudyHall);
            this.data.SaveChanges();

            return RedirectToAction("Index" , "StudyHall");
        }
    }
}
