namespace OpenCoursesAdmin.Services.Implementations
{
    using System;
    using System.Reflection;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using OpenCoursesAdmin.Services.Models.RequestModels;
    using RestSharp;

    public class ExternalCreator : IExternalCreator
    {
        public int CreateRecordReturnId<T>(T instance, string[] requestProperties) 
            where T : class
            => this.CreateRecordReturnId(instance, "", requestProperties);
        
        public int CreateRecordReturnId<T>(T instance, string urlParam, string[] requestProperties)
            where T : class
        {
            string url = typeof(RequestUrls)
                .GetField("Create" + typeof(T).Name, BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .GetValue(typeof(RequestUrls)).ToString();
           
            IRequestService requestService = urlParam != "" 
                ? new RequestService(String.Format(url, urlParam))  
                : new RequestService(url);

            string[] nameValuePairs = new string[requestProperties.Length * 2];

            for (int i = 0, j = 0; j < nameValuePairs.Length; i++, j += 2)
            {
                nameValuePairs[j] = requestProperties[i];
                nameValuePairs[j + 1] = typeof(T)
                    .GetProperty(requestProperties[i], BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(instance).ToString();
            }

            IRestResponse<DataList<T>> response = requestService.SendRequest<DataList<T>>(Method.POST, nameValuePairs);

            return (int)response.Data.Data[0].GetType()
                .GetProperty("Id")
                .GetValue(response.Data.Data[0], null);

            //TODO exception for cookie is Status OK but Data is null
        }
    }
}
