using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace movey.Actions
{
    public static class Communicator
    {
        // Set request timeout to something reasonable
        private static readonly int REQUEST_TIMEOUT = 5000;

        // Construct request
        public async static Task<string> Invoke(string url, string token)
        {
            // Configure webservice
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = REQUEST_TIMEOUT;

            // Add authentication header
            httpWebRequest.Headers["x-access-token"] = token;

            // Get response
            var httpWebResponse = await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
