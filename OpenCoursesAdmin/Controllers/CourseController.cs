namespace OpenCoursesAdmin.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using OpenCoursesAdmin.Data.Models.CourseModels;
    using OpenCoursesAdmin.Services;

    public class CourseController : Controller
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        
        //public IActionResult Create() => this.View();

        public IActionResult All()
        {
            List<CourseInstance> allOpenCourses =  this.courseService.GetAllOpenCoursesInstances();

            return this.View();
        }
    }
}