namespace TheThreeOwlsWebApp.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Models.StudyHall;

    public class StudyHall : Controller
    {
        private readonly ThreeOwlsDbContext data;

        public StudyHall(ThreeOwlsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(string title)
        {
            var studyHall = data.StudyHalls
                .Where(sh => sh.Title == title)
                .Select(sh => new StudyHallListingModel
                {
                    Image = sh.Image,
                    Text = sh.Text,
                    Title = sh.Title
                })
                .FirstOrDefault();

            return View(studyHall);
        }

        public IActionResult Summer()
        {
            var studyHall = data.StudyHalls
                .Where(sh => sh.Educational == false)
                .Select(sh => new StudyHallListingModel
                {
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
    }
}
