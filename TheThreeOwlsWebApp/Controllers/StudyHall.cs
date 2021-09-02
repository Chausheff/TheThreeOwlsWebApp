namespace TheThreeOwlsWebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class StudyHall : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Summer()
        {
            return View();
        }

        public IActionResult Educational()
        {
            return View();
        }
    }
}
