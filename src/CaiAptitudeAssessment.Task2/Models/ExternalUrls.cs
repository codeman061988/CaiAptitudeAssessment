using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Spotify external URL object
    /// </summary>
    public class ExternalUrls
    {
        /// <summary>
        /// An external, public URL to the object
        /// </summary>
        public Uri Spotify { get; set; }
    }
}