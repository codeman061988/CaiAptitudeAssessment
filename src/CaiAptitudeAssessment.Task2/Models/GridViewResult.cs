using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Represents a simplified, flattened result, as shown in the results gridview
    /// </summary>
    public class GridViewResult
    {
        /// <summary>
        /// The Album Id, not displayed but used for data enrichement purposes
        /// </summary>
        public string AlbumId { get; set; }

        /// <summary>
        /// The name of the album
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// The album cover URL, used to fetch and display the cover in the UI
        /// </summary>
        public string AlbumCoverUrl { get; set; }

        /// <summary>
        /// Artist name
        /// </summary>
        public string ArtistName { get; set; }

        /// <summary>
        /// Album release date
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Number of tracks in the album
        /// </summary>
        public long NumberOfTracks { get; set; }

        /// <summary>
        /// Popularity of the album
        /// </summary>
        public long Popularity { get; set; }
    }
}