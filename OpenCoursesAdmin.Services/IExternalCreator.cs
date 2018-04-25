namespace OpenCoursesAdmin.Services
{   
    public interface IExternalCreator
    {
        int CreateRecordReturnId<T>(T instance, string[] requestProperties) 
            where T : class;

        int CreateRecordReturnId<T>(T instance, string urlParam, string[] requestProperties)
            where T : class;
    }
}
