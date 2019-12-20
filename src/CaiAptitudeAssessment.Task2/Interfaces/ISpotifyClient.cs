using CaiAptitudeAssessment.Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiAptitudeAssessment.Task2.Interfaces
{
    /// <summary>
    /// RESTful client for communicating with Spotify APIs
    /// </summary>
    public interface ISpotifyClient
    {
        /// <summary>
        /// Retrieves information about an artist, per search query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<Artists> SearchArtistDetails(string query);

        /// <summary>
        /// Retrieves all album data associated with an artist Id passed in
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        Task<Albums> GetAlbumsByArtistId(string artistId);

        /// <summary>
        /// Retrieves albums by the comma delemited string of album ids passed in
        /// </summary>
        /// <param name="albumIds"></param>
        /// <returns></returns>
        Task<List<Album>> GetAlbumsByAlbumIds(string albumIds);
    }
}
