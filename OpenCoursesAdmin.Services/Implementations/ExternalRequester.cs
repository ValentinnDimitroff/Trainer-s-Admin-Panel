namespace OpenCoursesAdmin.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore.Query;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using OpenCoursesAdmin.Services.Models.RequestModels;
    using RestSharp;

    public class ExternalRequester : IExternalRequester
    {
        public int CreateRecordReturnId<T>(T instance, string[] requestProperties) 
            where T : class
            => this.CreateRecordReturnId(instance, "", requestProperties);

        public int CreateRecordReturnId<T>(T instance, string urlParam, string[] requestProperties)
            where T : class
            => this.ManipulateRecordReturnId(instance, "Create", urlParam, requestProperties);

        public int UpdateRecordReturnId<T>(T instance, string urlParam, string[] requestProperties)
            where T : class
            => this.ManipulateRecordReturnId(instance, "Update", urlParam, requestProperties);

        public List<T> GetListOfItems<T>(string urlParam)
            where T : class
            => this.SendRequest<T>(urlParam, new string[]{}).Data.Data;

        private int ManipulateRecordReturnId<T>(T instance, string action, string urlParam, string[] requestProperties)
            where T : class
        {
            string url = typeof(RequestUrls)
                .GetField(action + typeof(T).Name, BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .GetValue(typeof(RequestUrls)).ToString();

            string formatedUrl = urlParam != ""
                ? String.Format(url, urlParam)
                : url;

            string[] nameValuePairs = this.ParseRequestProperties(instance, requestProperties);

            IRestResponse<DataList<T>> response = this.SendRequest<T>(formatedUrl, nameValuePairs);

            return (int)response.Data.Data[0].GetType()
                .GetProperty("Id")
                .GetValue(response.Data.Data[0], null);
        }

        private IRestResponse<DataList<T>> SendRequest<T>(string urlParam, string[] requestParams)
            where T : class
        {
            IRequestService requestService = new RequestService(urlParam);
            
            IRestResponse<DataList<T>> response = requestService.SendRequest<DataList<T>>(Method.POST, requestParams);
            
            //TODO exception for cookie is Status OK but Data is null
            if (response.StatusCode == HttpStatusCode.OK && response.Data is null)
            {
                throw new AccessViolationException("Your cookie has been expired!");
            }

            return response;
        }

        private string[] ParseRequestProperties<T>(T instance, string[] requestProperties)
            where T : class
        {
            string[] nameValuePairs = new string[requestProperties.Length * 2];

            for (int i = 0, j = 0; j < nameValuePairs.Length; i++, j += 2)
            {
                nameValuePairs[j] = requestProperties[i];
                nameValuePairs[j + 1] = typeof(T)
                    .GetProperty(requestProperties[i], BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(instance)
                    .ToString();
            }

            return nameValuePairs;
        }
    }
}
