namespace TheThreeOwlsWebApp.Models.Blog
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static TheThreeOwlsWebApp.Data.DataConstants;
    public class AddArticleModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength)]
        [DisplayName("Заглавие")]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleTextMinLength)]
        [DisplayName("Текст")]
        public string Text { get; set; }

        [Required]
        [Url]
        [DisplayName("Път до снимката")]
        public string Image { get; set; }
    }
}
