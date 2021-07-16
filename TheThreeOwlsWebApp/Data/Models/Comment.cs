namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Comment
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string ArticleId { get; init; }
        public Article Article { get; init; }

        public bool Visible { get; set; } = true;

        [Required]
        public string Text { get; set; }

        [Required]
        public string CommenterId { get; init; }
        public User User { get; set; }
    }
}
