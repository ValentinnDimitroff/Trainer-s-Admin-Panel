namespace OpenCoursesAdmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OpenCoursesAdmin.Services;

    public partial class CourseController : Controller
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        
        public virtual IActionResult All() =>
             View(this.courseService.GetAllOpenCoursesInstancesWithUsersCount());

        public virtual IActionResult SurveysResults(string courseInstanceName) =>
             RedirectToAction(nameof(MVC.Survey.AverageResults), nameof(MVC.Survey), new { courseInstanceName });
    }
}