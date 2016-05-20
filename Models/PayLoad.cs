using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mi9
{
    public class PayLoad
    {
        public string Country { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public Image Image { get; set; }
        public string Language { get; set; }
        public Episode NextEpisode { get; set; }
        public string PrimaryColour { get; set; }
        public List<Season> Seasons { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string TvChannel { get; set; }
        public bool Drm { get; set; }
        public int EpisodeCount { get; set; }
    }

    public class Season
    {
        public string Slug { get; set; }
    }

    public class Image
    {
        public string ShowImage { get; set; }
    }

    public class Episode
    {
        public string Channel { get; set; }
        public string ChannelLogo { get; set; }
        public DateTime? Date { get; set; }

        [JsonProperty("html")]
        public string HtmlData { get; set; }
        [JsonProperty("url")]
        public string UrlData { get; set; }
    }



    public class PayLoadRequest
    {
        public List<PayLoad> PayLoad { get; set; }
        public int TotalRecords { get; set; }
    }
}