namespace OpenCoursesAdmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OpenCoursesAdmin.Data.Models.CourseModels;
    using OpenCoursesAdmin.Data.Models.SurveyModels;
    using OpenCoursesAdmin.Services.Interfaces;

    public partial class SurveyController : Controller
    {
        private readonly ISurveyService surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        public virtual IActionResult AverageResults(string courseInstanceName)
        {
            Survey middleSurvey = this.surveyService.GetMiddleSurvey(courseInstanceName);
            Survey finalSurvey = this.surveyService.GetFinalSurvey(courseInstanceName);

            return View( new CourseInstance()
            {
                Name = courseInstanceName,
                MiddleSurvey = middleSurvey,
                FinalSurvey = finalSurvey
            });

            //TODO write to excel
            //TODO thougher formula average curve
        }
    }
}