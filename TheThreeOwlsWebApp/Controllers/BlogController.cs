namespace TheThreeOwlsWebApp.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        public IActionResult Edit(string id)
        {
            var article = this.data.Articles
              .Where(a => a.Id == id)
              .Select(a => new BlogListingViewModel
              {
                  Id = a.Id,
                  Image = a.Image,
                  Title = a.Title,
                  Text = a.Text
              })
             .FirstOrDefault();

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(BlogListingViewModel article)
        {
            var editedArticle = data.Articles.FirstOrDefault(a => a.Id == article.Id);

            if (editedArticle == null)
            {
                return NotFound();
            }

            editedArticle.Image = article.Image;
            editedArticle.Title = article.Title;
            editedArticle.Text = article.Text;

            this.data.Articles.Update(editedArticle);
            this.data.SaveChanges();

            return RedirectToAction("All", "Blog");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var removedArticle = this.data.Articles
                .FirstOrDefault(a => a.Id == id);

            if (removedArticle == null)
            {
                return NotFound();
            }

            this.data.Articles.Remove(removedArticle);
            this.data.SaveChanges();
            return RedirectToAction("All", "Blog");
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Details(string Id)
        {
            var article = this.data.Articles
                .Where(a => a.Id == Id)
                 .Select(a => new BlogListingViewModel
                 {
                    Id = a.Id,
                    Image = a.Image,
                    Title = a.Title,
                    Text = a.Text
                 })
                 .FirstOrDefault();
            if (article != null)
            {
                return View(article);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize]
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
