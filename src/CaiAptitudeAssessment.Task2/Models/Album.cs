using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Spotify Album object
    /// </summary>
    public class Album
    {
        /// <summary>
        /// The type of the album: one of “album”, “single”, or “compilation”
        /// </summary>
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        /// <summary>
        /// The artists of the album. Each artist object includes a link in href to more detailed information 
        /// about the artist
        /// </summary>
        public List<Artist> Artists { get; set; }

        /// <summary>
        /// The markets in which the album is available: ISO 3166-1 alpha-2 country codes. 
        /// Note that an album is considered available in a market when at least 1 of its tracks is available in that market
        /// </summary>

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// Known external URLs for this album
        /// </summary>
        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the album
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the album
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The cover art for the album in various sizes, widest first
        /// </summary>
        public List<Image> Images { get; set; }

        /// <summary>
        /// The name of the album. In case of an album takedown, the value may be an empty string
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date the album was first released, for example 1981. 
        /// Depending on the precision, it might be shown as 1981-12 or 1981-12-15
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which release_date value is known: year , month , or day
        /// </summary>
        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonProperty("total_tracks")]
        public long TotalTracks { get; set; }

        /// <summary>
        /// The popularity of the artist. 
        /// The value will be between 0 and 100, with 100 being the most popular
        /// </summary>
        public long Popularity { get; set; }

        /// <summary>
        /// The object type: “album”
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the album
        /// </summary>
        public string Uri { get; set; }
    }
}