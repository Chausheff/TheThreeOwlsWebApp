namespace TheThreeOwlsWebApp.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Models.Contacts;

    public class ContactsController : Controller
    {
        IConfiguration iconfiguration;
        private readonly ThreeOwlsDbContext data;
        private readonly ContactsViewModel school;
        public ContactsController(IConfiguration iconfiguration, ThreeOwlsDbContext data)
        {
            this.iconfiguration = iconfiguration;
            this.data = data;
            this.school = data.Schools
                .Where(c => c.Id == 1)
                .Select(c => new ContactsViewModel
                {
                    Name = c.Name,
                    Address = c.Address,
                    Telephone = c.Telephone,
                    Email = c.Email,
                    FacebookPath = c.FacebookPath
                })
                .FirstOrDefault();
        }

        public IActionResult Index()
        {
            ViewBag.appEmailjs = this.iconfiguration["emailjs"];

            return View(school);
        }


        [Authorize]
        public IActionResult Edit()
        {
            var currentContacts = new ContactsEditModel
            {
                Name = school.Name,
                Address = school.Address,
                Telephone = school.Telephone,
                Email = school.Email,
                FacebookPath = school.FacebookPath
            };
            return View(currentContacts);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(ContactsEditModel info)
        {
            if (!ModelState.IsValid)
            {
                return View(info);
            }

            var schoolInfo = data.Schools.FirstOrDefault(i => i.Id == 1);

            schoolInfo.Name = info.Name;
            schoolInfo.Address = info.Address;
            schoolInfo.Telephone = info.Telephone;
            schoolInfo.Email = info.Email;
            schoolInfo.FacebookPath= info.FacebookPath;

            this.data.Schools.Update(schoolInfo);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
