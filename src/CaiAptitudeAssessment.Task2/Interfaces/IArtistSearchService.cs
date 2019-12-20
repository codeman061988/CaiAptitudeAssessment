using CaiAptitudeAssessment.Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiAptitudeAssessment.Task2.Interfaces
{
    /// <summary>
    /// Provides service(s) needed to fulfil business logic for the Artist Search component
    /// </summary>
    public interface IArtistSearchService
    {
        /// <summary>
        /// Takes a search term string, searches Spotify, reads and formats any results into a usable result set
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<ArtistSearchServiceResult> SearchArtistAlbums(string searchTerm);
    }
}
