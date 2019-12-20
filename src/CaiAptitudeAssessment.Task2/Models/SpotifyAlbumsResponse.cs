using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// The response object expected from Spotify Albums API
    /// </summary>
    public class SpotifyAlbumsResponse : SpotifyResponseBase
    {
        /// <summary>
        /// Collection of Spotify Album objects
        /// </summary>
        public List<Album> Albums { get; set; }
    }
}