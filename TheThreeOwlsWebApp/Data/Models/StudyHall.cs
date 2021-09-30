namespace TheThreeOwlsWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class StudyHall
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(StudyHallMaxLendth)]
        public string Title { get; set; }

        [Required]
        public bool Educational { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
