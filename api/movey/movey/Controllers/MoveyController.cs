using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using movey.Actions;

namespace movey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveyController : ControllerBase
    {
        Fetcher Fetcher;
        MoveyRootConfig Config;
        public MoveyController(IOptions<MoveyRootConfig> config)
        {
            Config = config.Value;
            Fetcher = new Fetcher(Config);
        }

        /// GET MOVIE PROVIDERS

        [HttpGet("GetMovieProviders")]
        [Produces("application/json")]
        public ActionResult<dynamic> GetMovieProviders()
        {
            return Config.movies.Select(x => x.provider).ToList();
        }


        /// GET MOVIE LIST

        [HttpGet("GetMovieListFromAll")]
        [Produces("application/json")]
        public ActionResult<dynamic> GetAllMoviesFromAll()
        {
            return Fetcher.FetchMovieListFromAll() ?? new object { };
        }

        [HttpGet("GetMovieListFromSingle/{provider}")]
        [Produces("application/json")]
        public ActionResult<dynamic> GetAllMoviesFromSingle(string provider)
        {
            return Fetcher.FetchMovieListFromSingle(provider) ?? new object { };
        }


        /// GET MOVIE DETAIL

        [HttpGet("GetMovieDetailFromSingle/{provider}/{id}")]
        [Produces("application/json")]
        public ActionResult<dynamic> GetMovieDetailFromSingle(string provider, string id)
        {
            return Fetcher.FetchMovieDetailFromSingle(provider, id) ?? new object { };
        }
    }
}
