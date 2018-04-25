namespace OpenCoursesAdmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CourseController : Controller
    {
        //[HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}