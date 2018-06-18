namespace OpenCoursesAdmin.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using OpenCoursesAdmin.Models;
    using OpenCoursesAdmin.Services;

    public partial class HomeController : Controller
    {
        private readonly ICourseService courseService;

        public HomeController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public virtual IActionResult Index() => View();

        public virtual IActionResult Courses() => this.RedirectToAction("All", "Course");

        public virtual IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public virtual IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public virtual IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
