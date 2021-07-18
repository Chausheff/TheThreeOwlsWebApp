namespace TheThreeOwlsWebApp.Models.Intro
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class CarouselIntroListingModel
    {
        public string Id { get; init; }

        [Required]
        public string Text { get; init; }

        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string Author { get; init; }

        [Range(IntroUserMinAge,IntroUserMaxAge)]
        public int AuthorAge { get; init; }

        [Url]
        public string Picture { get; set; } 
    }
}
