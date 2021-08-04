namespace TheThreeOwlsWebApp.Models.Home
{
    using System.Collections.Generic;
    using TheThreeOwlsWebApp.Models.Courses;
    using TheThreeOwlsWebApp.Models.Intro;

    public class HomeViewModel
    {
        public List<CourseListingViewModel> courses { get; set; }
        public List<CarouselIntroListingModel> intros { get; set; }
    }
}
