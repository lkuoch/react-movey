namespace movey.Models
{
    public class MoviesListResponseModel
    {
        // Input props
        public string _Provider { get; set; }
        private MoviesListPayload Payload { get; set; }

        public MoviesListResponseModel(string provider, MoviesListPayload payload)
        {
            _Provider = provider;
            Payload = payload;
        }

        // Response props
        public string Title => Payload.Title;
        public string Id => Payload.Id;
        public string Year => Payload.Year;
        public string Type => Payload.Type;
        public string Poster => Payload.Poster;

        public object MovieDetail => new object { };
    }
}
