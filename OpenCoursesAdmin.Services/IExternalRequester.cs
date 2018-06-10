namespace OpenCoursesAdmin.Services
{
    using System.Collections.Generic;

    public interface IExternalRequester
    {
        int CreateRecordReturnId<T>(T instance, string[] requestProperties) 
            where T : class;

        int CreateRecordReturnId<T>(T instance, string urlParam, string[] requestProperties)
            where T : class;

        int UpdateRecordReturnId<T>(T instance, string urlParam, string[] requestProperties)
            where T : class;

        List<T> GetListOfItems<T>(string urlParam)
            where T : class;
    }
}
