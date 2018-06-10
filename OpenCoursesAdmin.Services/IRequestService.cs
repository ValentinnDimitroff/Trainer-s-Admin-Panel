namespace OpenCoursesAdmin.Services
{
    using System.Collections.Generic;
    using RestSharp;

    public interface IRequestService
    {
        IRestResponse<T> SendGetRequest<T>(params string[] nameValuePairs)
            where T : new();

        IRestResponse<T> SendPostRequest<T>(params string[] nameValuePairs)
            where T : new();

       IRestResponse<T> SendRequest<T>(Method requestedMethod, params string[] parameters)
            where T : new();
    }
}
