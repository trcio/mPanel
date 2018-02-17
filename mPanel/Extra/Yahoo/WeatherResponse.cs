using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mPanel.Extra.Yahoo
{
    [DataContract]
    public class Units
    {
        [DataMember(Name = "distance")]
        public string Distance { get; set; }

        [DataMember(Name = "pressure")]
        public string Pressure { get; set; }

        [DataMember(Name = "speed")]
        public string Speed { get; set; }

        [DataMember(Name = "temperature")]
        public string Temperature { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "region")]
        public string Region { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember(Name = "chill")]
        public string Chill { get; set; }

        [DataMember(Name = "direction")]
        public string Direction { get; set; }

        [DataMember(Name = "speed")]
        public string Speed { get; set; }
    }

    [DataContract]
    public class Atmosphere
    {
        [DataMember(Name = "humidity")]
        public string Humidity { get; set; }

        [DataMember(Name = "pressure")]
        public string Pressure { get; set; }

        [DataMember(Name = "rising")]
        public string Rising { get; set; }

        [DataMember(Name = "visibility")]
        public string Visibility { get; set; }
    }

    [DataContract]
    public class Astronomy
    {
        [DataMember(Name = "sunrise")]
        public string Sunrise { get; set; }

        [DataMember(Name = "sunset")]
        public string Sunset { get; set; }
    }

    [DataContract]
    public class Image
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "width")]
        public string Width { get; set; }

        [DataMember(Name = "height")]
        public string Height { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

    [DataContract]
    public class Condition
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "temp")]
        public string Temp { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }

    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "day")]
        public string Day { get; set; }

        [DataMember(Name = "high")]
        public string High { get; set; }

        [DataMember(Name = "low")]
        public string Low { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }

    [DataContract]
    public class Guid
    {
        [DataMember(Name = "isPermaLink")]
        public string IsPermaLink { get; set; }
    }

    [DataContract]
    public class Item
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "lat")]
        public string Lat { get; set; }

        [DataMember(Name = "@long")]
        public string Long { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "pubDate")]
        public string PubDate { get; set; }

        [DataMember(Name = "condition")]
        public Condition Condition { get; set; }

        [DataMember(Name = "forecast")]
        public List<Forecast> Forecast { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "guid")]
        public Guid Guid { get; set; }
    }

    [DataContract]
    public class Channel
    {
        [DataMember(Name = "units")]
        public Units Units { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "lastBuildDate")]
        public string LastBuildDate { get; set; }

        [DataMember(Name = "ttl")]
        public string Ttl { get; set; }

        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "wind")]
        public Wind Wind { get; set; }

        [DataMember(Name = "atmosphere")]
        public Atmosphere Atmosphere { get; set; }

        [DataMember(Name = "astronomy")]
        public Astronomy Astronomy { get; set; }

        [DataMember(Name = "image")]
        public Image Image { get; set; }

        [DataMember(Name = "item")]
        public Item Item { get; set; }
    }

    [DataContract]
    public class Results
    {
        [DataMember(Name = "channel")]
        public Channel Channel { get; set; }
    }

    [DataContract]
    public class Query
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "created")]
        public string Created { get; set; }

        [DataMember(Name = "lang")]
        public string Lang { get; set; }

        [DataMember(Name = "results")]
        public Results Results { get; set; }
    }

    [DataContract]
    public class WeatherResponse
    {
        [DataMember(Name = "query")]
        public Query Query { get; set; }
    }
}
