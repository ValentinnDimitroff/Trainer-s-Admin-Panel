namespace OpenCoursesAdmin.Services.Interfaces
{
    using OpenCoursesAdmin.Data.Models.SurveyModels;

    public interface ISurveyService
    {
        Survey GetMiddleSurvey(string courseInstanceName);

        Survey GetFinalSurvey(string courseInstanceName);
    }
}
