namespace movey.Models
{
    public class MovieDetailResponseModel
    {
        // Input props
        public string _Provider { get; set; }
        private MovieDetailModel Payload { get; set; }

        public MovieDetailResponseModel(string provider, MovieDetailModel payload)
        {
            _Provider = provider; 
            Payload = payload;
        }

        // Response props
        public string Title => Title ?? "";
        public string Year => Year ?? "";
        public string Rated => Rated ?? "";
        public string Released => Released ?? "";
        public string Runtime => Runtime ?? "";
        public string Genre => Genre ?? "";
        public string Director => Director ?? "";
        public string Writer => Writer ?? "";
        public string Actors => Actors ?? "";
        public string Plot => Plot ?? "";
        public string Language => Language ?? "";
        public string Country => Country ?? "";
        public string Awards => Awards ?? "";
        public string Poster => Poster ?? "";
        public string Metascore => Metascore ?? "";
        public string Rating => Rating ?? "";
        public string Votes => Votes ?? "";
        public string Id => Id ?? "";
        public string Type => Type ?? "";
        public string Price => Price ?? "";
    }
}
