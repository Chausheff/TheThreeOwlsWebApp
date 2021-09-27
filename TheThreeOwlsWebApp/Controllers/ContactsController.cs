namespace TheThreeOwlsWebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class ContactsController : Controller
    {
        IConfiguration iconfiguration;
        public ContactsController(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            ViewBag.appEmailjs = this.iconfiguration["emailjs"];
            return View();
        }
    }
}
