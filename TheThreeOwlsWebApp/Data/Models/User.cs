namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserPasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Phone]
        public long Phone { get; set; }

        public bool IsAdmin { get; set; } = false;

        public bool IsBlocked { get; set; } = false;

        public string Picture { get; set; }
    }
}
