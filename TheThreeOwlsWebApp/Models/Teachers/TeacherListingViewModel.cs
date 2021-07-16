namespace TheThreeOwlsWebApp.Models.Teachers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class TeacherListingViewModel
    {
        public string Id { get; init; }

        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string FirstName { get; init; }

        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string LastName { get; init; }

        [Required]
        [Url]
        public string Picture { get; init; }

        [Required]
        public string Info { get; init; }
    }
}
