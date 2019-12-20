using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Spotify artist object (full)
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Known external URLs for this artist
        /// </summary>
        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        /// <summary>
        /// Information about the followers of the artist
        /// </summary>
        public Followers Followers { get; set; }

        /// <summary>
        /// A list of the genres the artist is associated with. 
        /// For example: "Prog Rock" , "Post-Grunge". (If not yet classified, the array is empty.)
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the artist
        /// </summary>
        public Uri Href { get; set; }

        /// <summary>
        /// The Spotify ID for the artist
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Images of the artist in various sizes, widest first
        /// </summary>
        public List<Image> Images { get; set; }

        /// <summary>
        /// The name of the artist
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The popularity of the artist. The value will be between 0 and 100, with 100 being the most popular. 
        /// The artist’s popularity is calculated from the popularity of all the artist’s tracks.
        /// </summary>
        public long Popularity { get; set; }

        /// <summary>
        /// The object type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the artist
        /// </summary>
        public string Uri { get; set; }
    }
}