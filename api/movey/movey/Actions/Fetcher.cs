using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using movey.Models;
using System.Linq;

namespace movey.Actions
{
    public class Fetcher
    {
        // Endpoint
        MoveyRootConfig Config;

        // Constructor
        public Fetcher(MoveyRootConfig config)
        {
            Config = config;
        }

        /// ====================================================================
        
        /// MOVIE LIST
        public dynamic FetchMovieListFromAll()
        {
            var results = new List<List<MoviesListResponseModel>>() { };
            foreach (string movieProvider in Config.movies.Select(x => x.provider).ToList())
            {
                List<MoviesListResponseModel> element = FetchMovieListFromSingle(movieProvider);
                if (element != null)
                {
                    results.Add(element);
                }
            }

            return results.SelectMany(e => e).ToList();
        }


        public List<MoviesListResponseModel> FetchMovieListFromSingle(string provider)
        {
            try
            {
                // Get appropriate url
                string endpoint = Config.baseEndpoint + Config.movies.Single(x => x.provider == provider).moviesList;

                // Get webservice response and destructure it
                string response = Communicator.Invoke(endpoint, Config.token).Result;
                var payloadList = JsonConvert.DeserializeObject<MoviesListModel>(response) ?? 
                    throw new Exception("Could not deserialize ModiesListModel\r\n " + JsonConvert.SerializeObject(response));

                // Return a list of movies
                var result = new List<MoviesListResponseModel>();
                foreach(var payload in payloadList.Movies)
                {
                    result.Add(new MoviesListResponseModel(provider, payload));
                }

                return result;
            }
            catch (Exception e)
            {
                // Should log the exception
                Console.WriteLine(e);

                // Can't find movie provider so return blank object
                return null;
            }
        }

        /// ====================================================================

        /// MOVIE DETAIL 

        public List<MovieDetailModel> FetchMovieDetailFromSingle(string provider, string id)
        {
            try
            {
                // Get appropri ate url
                string endpoint = Config.baseEndpoint + Config.movies.Single(x => x.provider == provider).movieDetail + id;

                // Get webservice response and destructure it
                string response = Communicator.Invoke(endpoint, Config.token).Result;
                var result = new List<MovieDetailModel>();

                result.Add(JsonConvert.DeserializeObject<MovieDetailModel>(response) ??
                    throw new Exception("Could not deserialize MovieDetailModel\r\n " + JsonConvert.SerializeObject(response)));

                return result;
            }
            catch (Exception e)
            {
                // Should log the exception
                Console.WriteLine(e);

                // Can't find movie provider so return blank object
                return null;
            }
        }
        
    }
}
