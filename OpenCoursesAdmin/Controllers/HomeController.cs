namespace OpenCoursesAdmin.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using OpenCoursesAdmin.Models;
    using OpenCoursesAdmin.Services;

    public class HomeController : Controller
    {
        private readonly ICourseService courseService;

        public HomeController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult Index() => View();

        public IActionResult Courses() => this.RedirectToAction("All", "Course");

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
