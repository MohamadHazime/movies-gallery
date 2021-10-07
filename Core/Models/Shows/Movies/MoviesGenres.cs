using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MoviesGenres
    {
        private static List<Genre> genres = null;

        public async static Task<List<Genre>> GetGenresList(string apiKey)
        {
            if(genres == null)
            {
                var _client = MyRestClient.GetRestClientObject();

                var request = new RestRequest("genre/movie/list")
                    .AddParameter("api_key", apiKey);
                var response = await _client.GetAsync<GenresResponse>(request);

                genres = response.Genres;
            }

            return genres;
        }
    }
}