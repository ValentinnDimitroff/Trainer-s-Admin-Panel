namespace OpenCoursesAdmin.Services
{
    using System.Collections.Generic;
    using RestSharp;

    public interface IRequestService
    {
        IRestResponse<T> SendRequest<T>(Method requestedMethod, params string[] parameters)
            where T : new();
    }
}
