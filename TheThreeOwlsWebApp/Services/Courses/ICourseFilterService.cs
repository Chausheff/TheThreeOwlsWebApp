namespace TheThreeOwlsWebApp.Services.Courses
{
    using System.Collections.Generic;
    using TheThreeOwlsWebApp.Models.Courses;

    public interface ICourseFilterService
    {
        IEnumerable<CourseListingViewModel> Courses(string modifier,string lang);
        CourseListingViewModel TakeCourse(string Id);
    }
}
