using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Represents common data that could be captured in any Spotify API response
    /// </summary>
    public class SpotifyResponseBase
    {
        /// <summary>
        /// In the case of a non-authenticaton error: an object with both an HttpStatus and a message pertaining to the error.
        /// In the case of an authentiction error: A string containing high level description of the error as specified in RFC 6749 Section 5.2
        /// </summary>
        public dynamic Error { get; set; }

        /// <summary>
        /// A more detailed description of the error as specified in RFC 6749 Section 4.1.2.1
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}