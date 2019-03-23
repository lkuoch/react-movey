using System.Collections.Generic;

namespace movey
{
    public class MoveyRootConfig
    {
        /* Stored in appsettings.json
             
            {
              "provider": "cinemaworld",
              "moviesList": "cinemaworld/movies",
              "movieDetail": "cinemaworld/movie/"
            },
            {
              "provider":  "filmworld",
              "moviesList": "filmworld/movies",
              "movieDetail": "filmworld/movie/"
            }
        */

        // Url
        public string baseEndpoint { get; set; }

        // Token
        public string token { get; set; }

        public List<ProviderConfig> movies { get; set; }
    }

    public class ProviderConfig
    {
        public string provider { get; set; }
        public string moviesList { get; set; }
        public string movieDetail { get; set; }
    }
}
