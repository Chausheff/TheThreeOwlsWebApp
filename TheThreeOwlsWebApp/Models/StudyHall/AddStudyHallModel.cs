namespace TheThreeOwlsWebApp.Models.StudyHall
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static TheThreeOwlsWebApp.Data.DataConstants;

    public class AddStudyHallModel
    {
        [Required]
        [StringLength(StudyHallMaxLendth, MinimumLength = StudyHallMinLendth)]
        [DisplayName("Заглавие")]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleTextMinLength)]
        [DisplayName("Текст")]
        public string Text { get; set; }

        [Required]
        [DisplayName("Ученически курс")]
        public bool Educational { get; set; }

        [Required]
        [Url]
        [DisplayName("Път до снимката")]
        public string Image { get; set; }
    }
}
