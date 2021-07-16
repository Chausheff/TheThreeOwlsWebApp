namespace TheThreeOwlsWebApp.Models.Teachers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class TeacherAddingViewModel
    {
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
        [StringLength(TeacherInfoMaxLength, MinimumLength = TeacherInfoMinLength)]
        public string Info { get; init; }
    }
}
