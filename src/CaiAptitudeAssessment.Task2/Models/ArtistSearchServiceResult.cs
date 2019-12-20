using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Models
{
    /// <summary>
    /// Represents an ArtistSearch service result, signaling to the consumer whether a search was successful or a failure
    /// </summary>
    public class ArtistSearchServiceResult
    {
        /// <summary>
        /// The result flag, allowing the consumer to quickly evaluate the result
        /// </summary>
        public ArtistSearchServiceResultFlag ServiceResultFlag { get; set; }

        /// <summary>
        /// The result set
        /// </summary>
        public List<GridViewResult> Results { get; set; }
    }

    /// <summary>
    /// Provides a flag for the ArtistSearchServiceResult
    /// </summary>
    public enum ArtistSearchServiceResultFlag
    {
        ResultsFound,
        ResultsNotFound,
        Error
    }
}