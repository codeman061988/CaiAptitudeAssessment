using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Spotify image object
    /// </summary>
    public class Image
    {
        /// <summary>
        /// The image height in pixels
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// The source URL of the image
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The image width in pixels
        /// </summary>
        public long Width { get; set; }
    }
}