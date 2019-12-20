using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Spotify Artists response object
    /// </summary>
    public class Artists
    {
        /// <summary>
        /// A link to the Web API endpoint returning the full result of the request
        /// </summary>
        public Uri Href { get; set; }

        /// <summary>
        /// The Artists Requested
        /// </summary>
        public List<Artist> Items { get; set; }

        /// <summary>
        /// The maximum number of items in the response (as set in the query or by default)
        /// </summary>
        public long Limit { get; set; }

        /// <summary>
        /// URL to the next page of items
        /// </summary>
        public Uri Next { get; set; }

        /// <summary>
        /// The offset of the items returned
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// URL to the previous page of items
        /// </summary>
        public Uri Previous { get; set; }

        /// <summary>
        /// The maximum number of items available to return
        /// </summary>
        public long Total { get; set; }
    }
}