using CaiAptitudeAssessment.Task2.Interfaces;
using CaiAptitudeAssessment.Task2.Models;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CaiAptitudeAssessment.Task2.Clients
{
    /// <inheritdoc />
    public class SpotifyClient : ISpotifyClient
    {
        private readonly IFlurlClient _flurlClient;
        private SpotifyAuthorizationResponse _auth;

        // Contants to represent key data needed to inoke APIs
        // This would normally be placed in Web.Config or appsettings.json for this type of application
        // but for the sake of this assessment demo, 
        // we'll keep it simple and "hard code" them. 
        private const string SPOTIFY_API_BASE = "https://api.spotify.com/v1/";
        private const string SPOTIFY_API_AUTH = "https://accounts.spotify.com/api/token";
        private const string SPOTIFY_API_CLIENT_ID = "1d20c92f8c1c4290abc94a5133fa35cf";
        private const string SPOTIFY_API_CLIENT_SECRET = "efd6090ceb8b4f149ec7480b23f503c8";

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyClient"/> class
        /// </summary>
        public SpotifyClient(IFlurlClientFactory flurlClientFactory)
        {
            // Be sure contstructor params are not null during DI
            if (flurlClientFactory == null) { throw new ArgumentNullException(nameof(flurlClientFactory)); }

            // Set our reuable Flurl client up with the base Spotify URL
            _flurlClient = flurlClientFactory.Get(SPOTIFY_API_BASE);

            // Instantiate the reusable _auth variable with a new instance of SpotifyAuthorizationResponse
            // ,which will be assigned to each time a request is made
            _auth = new SpotifyAuthorizationResponse();
        }

        /// <inheritdoc />
        public async Task<Artists> SearchArtistDetails(string query)
        {
            try
            {
                // Get Authorization
                await GetAuthorization().ConfigureAwait(false);

                // Create / execute Flurl request, bind to response object
                var response = await _flurlClient
                    .Request("search")
                    .SetQueryParams(new
                    {
                        q = query,
                        type = "artist"
                    })
                    .WithOAuthBearerToken(_auth.AccessToken)
                    .GetAsync()
                    .ReceiveJson<SpotifyArtistsResponse>()
                    .ConfigureAwait(false);

                return response.Artists;
            }
            catch (FlurlHttpException)
            {
                // We would normally log this
                throw;
            }
            catch (Exception)
            {
                // We would normally log this
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Albums> GetAlbumsByArtistId(string artistId)
        {
            try
            {
                // Get Authorization
                await GetAuthorization().ConfigureAwait(false);

                // Create / execute Flurl request, bind to response object
                var response = await _flurlClient
                    .Request("artists", artistId, "albums")
                    .SetQueryParams(new { 
                        market="US"
                    })
                    .WithOAuthBearerToken(_auth.AccessToken)
                    .GetAsync()
                    .ReceiveJson<Albums>()
                    .ConfigureAwait(false);

                return response;
            }
            catch (FlurlHttpException)
            {
                // We would normally log this
                throw;
            }
            catch (Exception)
            {
                // We would normally log this
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<List<Album>> GetAlbumsByAlbumIds(string albumIds)
        {
            try
            {
                // Get Authorization
                await GetAuthorization().ConfigureAwait(false);

                // Create / execute Flurl request, bind to response object
                var response = await _flurlClient
                    .Request("albums")
                    .SetQueryParam("ids",albumIds)
                    .WithOAuthBearerToken(_auth.AccessToken)
                    .GetAsync()
                    .ReceiveJson<SpotifyAlbumsResponse>()
                    .ConfigureAwait(false);

                return response.Albums;
            }
            catch (FlurlHttpException)
            {
                // We would normally log this
                throw;
            }
            catch (Exception)
            {
                // We would normally log this
                throw;
            }
        }

        /// <summary>
        /// Retrieves an authorization token from Spotify using the Client Credentials flow
        /// Assigns response to reusable _auth object when invoked
        /// https://developer.spotify.com/documentation/general/guides/authorization-guide/#client-credentials-flow
        /// </summary>
        /// <returns></returns>
        private async Task GetAuthorization()
        {
            // Use simple HttpClient for this request, as Flurl does not do as well for these types of requests
            try
            {
                using (var client = new HttpClient())
                {
                    // We need to encode our combination of ClientId and Client Secret, which will be converted to Base64, 
                    // per Spotify's Authorization flow documentation
                    var clientCreds = Encoding.UTF8.GetBytes($"{SPOTIFY_API_CLIENT_ID}:{SPOTIFY_API_CLIENT_SECRET}");

                    // Set request headers
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(clientCreds));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a new key/value post message
                    var postMessage = new Dictionary<string, string>();
                    postMessage.Add("grant_type", "client_credentials");

                    // Configure request with endpoint
                    var request = new HttpRequestMessage(HttpMethod.Post, SPOTIFY_API_AUTH)
                    {
                        Content = new FormUrlEncodedContent(postMessage)
                    };

                    // Perform request, initialize response variable for reference
                    var response = await client.SendAsync(request).ConfigureAwait(false);

                    // Was the request a success?
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize and return response
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        _auth = JsonConvert.DeserializeObject<SpotifyAuthorizationResponse>(json);
                    }
                    else
                    {
                        // Unable to retrieve token
                        throw new ApplicationException("Unable to retrieve access token from Spotify");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unable to retrieve access token from Spotify: {ex.Message}");
            }
        }
    }
}