namespace OpenCoursesAdmin.Services.Implementations
{
    using RestSharp;
    using Constants;

    public class RequestService : IRequestService
    {
        private RestClient client;

        public RequestService(string baseUrl)
        {
            this.client = new RestClient(baseUrl);
        }

        public IRestResponse<T> SendRequest<T>(Method requestedMethod, params string[] nameValuePairs)
            where T : new()
        {
            IRestRequest request = new RestRequest(requestedMethod);
            request.AddCookie(Authentication.CookieName, Authentication.Cookie);

            if (nameValuePairs.Length > 0 && nameValuePairs.Length % 2 == 0)
            {
                for (int i = 0; i < nameValuePairs.Length; i += 2)
                {
                    request.AddParameter(nameValuePairs[i], nameValuePairs[i + 1]);
                }
            }

            return this.client.Execute<T>(request);
        }
    }
}
