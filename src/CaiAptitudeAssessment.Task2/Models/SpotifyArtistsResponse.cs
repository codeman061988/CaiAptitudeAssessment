using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// The response object expected from Spotify Artists API
    /// </summary>
    public class SpotifyArtistsResponse : SpotifyResponseBase
    {
        /// <summary>
        /// Response paging object for Artists
        /// </summary>
        public Artists Artists { get; set; }

        /// <summary>
        /// Response paging object for Albums
        /// </summary>
        public Albums Albums { get; set; }
    }
}