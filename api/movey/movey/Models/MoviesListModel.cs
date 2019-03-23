using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace movey.Models
{
    public partial class MoviesListModel
    {
        public List<MoviesListPayload> Movies { get; set; }
    }

    public partial class MoviesListPayload
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
