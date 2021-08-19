namespace TheThreeOwlsWebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Data.Models;
    using TheThreeOwlsWebApp.Models.Blog;

    public class BlogController : Controller
    {
        private readonly ThreeOwlsDbContext data;

        public BlogController(ThreeOwlsDbContext data)
        {
            this.data = data;
        }
        public IActionResult All()
        {
            var articles = this.data.Articles
                 .Select(a => new BlogListingViewModel
                 {
                     Id = a.Id,
                     Title = a.Title,
                     Text = a.Text,
                     Image = a.Image
                 })
                 .ToList();
            return View(articles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddArticleModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            var newArticle = new Article
            {
                Title = article.Title,
                Text = article.Text,
                Image = article.Image
            };

            this.data.Articles.Add(newArticle);
            this.data.SaveChanges();

            return RedirectToAction("All", "Blog");
        }
    }
}
