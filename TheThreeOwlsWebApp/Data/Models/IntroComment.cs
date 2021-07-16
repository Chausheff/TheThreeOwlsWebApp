namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class IntroComment
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Text { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string Author { get; init; }

        public int AuthorAge { get; init; }

        public string Picture { get; set; } = "wwwroot/images/Logo.jpg";
    }
}
