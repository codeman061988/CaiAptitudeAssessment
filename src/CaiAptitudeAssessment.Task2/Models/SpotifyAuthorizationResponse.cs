using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Response object expected from Spotify Authorization API
    /// </summary>
    public class SpotifyAuthorizationResponse
    {
        /// <summary>
        /// Access token obtained
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Type of authorization token retrieved
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Time in which token expires
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }
}