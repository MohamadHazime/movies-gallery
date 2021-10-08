using RestSharp;

namespace Gallery.Domain
{
    public class MyRestClient
    {
        private const string _baseUrl = "https://api.themoviedb.org/3/";
        private static RestClient restClientObj = null;

        public static RestClient GetRestClientObject()
        {
            if(restClientObj == null)
            {
                restClientObj = new RestClient(_baseUrl);
            }

            return restClientObj;
        }
    }
}
