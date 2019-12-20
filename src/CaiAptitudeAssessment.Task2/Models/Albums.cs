using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Spotify Albums response object
    /// </summary>
    public class Albums
    {
        /// <summary>
        /// A link to the Web API endpoint returning the full result of the request
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The Albums Requested
        /// </summary>
        public List<Album> Items { get; set; }

        /// <summary>
        /// The maximum number of items in the response (as set in the query or by default)
        /// </summary>
        public long Limit { get; set; }

        /// <summary>
        /// URL to the next page of items
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The offset of the items returned
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// URL to the previous page of items
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// The maximum number of items available to return
        /// </summary>
        public long Total { get; set; }
    }
}