namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Teacher
    {

        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [Url]
        public string Picture { get; set; }

        [Required]
        [MaxLength(TeacherInfoMaxLength)]
        public string Info { get; set; }
    }
}
