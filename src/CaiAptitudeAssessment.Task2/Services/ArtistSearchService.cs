using CaiAptitudeAssessment.Task2.Interfaces;
using CaiAptitudeAssessment.Task2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Services
{
    /// <inheritdoc />
    public class ArtistSearchService : IArtistSearchService
    {
        private readonly ISpotifyClient _spotifyClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistSearchService"/> class
        /// </summary>
        /// <param name="spotifyClient"></param>
        public ArtistSearchService(ISpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

        /// <inheritdoc />
        public async Task<ArtistSearchServiceResult> SearchArtistAlbums(string searchTerm) 
        {
            // Instantiate new result object
            ArtistSearchServiceResult serviceResult = new ArtistSearchServiceResult();

            try
            {
                // Search for artist at spotify
                var artistResults =
                    await _spotifyClient.SearchArtistDetails(searchTerm).ConfigureAwait(false);

                // Did we get results?
                if (artistResults != null && artistResults.Items.Any())
                {
                    // For simplicity sake of this demo, take first artist if multiple are returned
                    var firstArtist = artistResults.Items.First();

                    // Assign artist Id
                    var artistId = firstArtist.Id;

                    // Now get albums associated with artist
                    var albumResults = await _spotifyClient.GetAlbumsByArtistId(artistId).ConfigureAwait(false);

                    // Did we get results?
                    if (albumResults != null && albumResults.Items.Any())
                    {
                        var gridData = await BuildGridviewResults(albumResults.Items);

                        serviceResult.ServiceResultFlag = ArtistSearchServiceResultFlag.ResultsFound;
                        serviceResult.Results = gridData;

                        return serviceResult;
                    }

                    // Fail over to not found status
                    serviceResult.ServiceResultFlag = ArtistSearchServiceResultFlag.ResultsNotFound;
                    return serviceResult;
                }

                // Fail over to not found status if found conditions not met
                serviceResult.ServiceResultFlag = ArtistSearchServiceResultFlag.ResultsNotFound;
                return serviceResult;
            }
            catch (Exception)
            {
                // We would typically want to log the exception, if this was a full on project with a db connection
                // My choice of libraries would be Serilog

                // Return service result object with Error flag
                serviceResult.ServiceResultFlag = ArtistSearchServiceResultFlag.Error;
                return serviceResult;
            }
        }

        /// <summary>
        /// Builds gridview results by taking in Album model and mapping it to the desired gridview result model
        /// </summary>
        /// <param name="albums"></param>
        /// <returns></returns>
        private async Task<List<GridViewResult>> BuildGridviewResults(List<Album> albums)
        {
            // Map results of DTO to Gridview format object
            // I would typically do this will Automapper, creating mapper classes for each aggregate or related business object
            // Since we really only need to convert one, small object, we'll use a simple lamda expression
            var results = albums
                .Select(al => new GridViewResult
                {
                    AlbumId = al.Id,
                    AlbumName = al.Name,

                    // Here we'll take the first artist in the list of contributing artists
                    // We could create a more complex grid system and display all contributing artists but 
                    // for simplicity sake, we'll keep it simple
                    ArtistName = al.Artists.First().Name,
                    ReleaseDate = al.ReleaseDate,
                    NumberOfTracks = al.TotalTracks
                })
                .ToList();

            // Enrich results 
            await EnrichGridViewResults(results);

            // Format results
            FormatGridViewResults(results);

            return results;
        }

        /// <summary>
        /// Enriches the grid view results with data which may not have come from 
        /// </summary>
        /// <param name="gridViewResults"></param>
        private async Task EnrichGridViewResults(List<GridViewResult> gridViewResults)
        {
            // Get list of album Ids
            List<string> albumIds = gridViewResults.Select(r => r.AlbumId).ToList();

            // Create single, comma delemited string from list for Spotify's Albums API
            string albumIdListStr = string.Join(",", albumIds.ToArray());

            // Retrieve full album details via Albums API
            var fullAlbumDetails =
                await _spotifyClient.GetAlbumsByAlbumIds(albumIdListStr).ConfigureAwait(false);

            // Enrich Grid results with any missing album detail
            foreach (var result in gridViewResults)
            {
                // Query collection using the Id of the current iteration
                var fullAlbum = fullAlbumDetails.FirstOrDefault(det => det.Id == result.AlbumId);

                // Add popularity
                result.Popularity = fullAlbum.Popularity;

                // Add album cover URL
                result.AlbumCoverUrl = fullAlbum.Images.First().Url;
            }
        }

        /// <summary>
        /// Formats the individule fields of the grid view results as needed, i.e. Dates
        /// </summary>
        /// <param name="gridViewResults"></param>
        private void FormatGridViewResults(List<GridViewResult> gridViewResults)
        {
            // Provide culture info for purposes of Datetime compare and format
            // To keep it simple, we'll use en-US but there could be cases where you would want to match the culture
            // ..specified on the server
            CultureInfo enUS = new CultureInfo("en-US");

            // Iterate through gridview results collection
            foreach (var result in gridViewResults)
            {
                // If not empty, Format Release Date to a more familiar format for general audiences
                string spotifyDefaultDateFormat = "yyyy-MM-dd";
                string simplifiedDateFormat = "MM/dd/yyyy";

                bool isSpotifyDetaultFormat = DateTime.TryParseExact(result.ReleaseDate, spotifyDefaultDateFormat, enUS, DateTimeStyles.None, out _);

                if (!string.IsNullOrWhiteSpace(result.ReleaseDate) && isSpotifyDetaultFormat)
                {
                    result.ReleaseDate =
                        DateTime.ParseExact(result.ReleaseDate, spotifyDefaultDateFormat, CultureInfo.InvariantCulture).ToString(simplifiedDateFormat);
                }
            }
        }
    }
}