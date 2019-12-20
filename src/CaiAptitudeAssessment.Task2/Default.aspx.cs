using CaiAptitudeAssessment.Task2.Interfaces;
using CaiAptitudeAssessment.Task2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaiAptitudeAssessment.Task2
{
    /// <summary>
    /// Code behind for the Default page
    /// </summary>
    public partial class _Default : Page
    {
        private readonly IArtistSearchService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="_Default"/> class
        /// </summary>
        public _Default(IArtistSearchService service)
        {
            _service = service;
        }

        /// <summary>
        /// Page Load event(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide controls with no data to show on page load
            SearchResultsGridView.Visible = false;
            NotFoundAlertDiv.Visible = false;
            ErrorDiv.Visible = false;
        }

        /// <summary>
        /// Events that take place when an artist is searched for
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void OnSearchArtist(object sender, EventArgs e)
        {
            // Take contents of input textbox and perform search using the service
            var serviceResult =
                await _service.SearchArtistAlbums(ArtistSearchInputTextBox.Text).ConfigureAwait(false);

            // What were the service results?
            switch (serviceResult.ServiceResultFlag)
            {
                // Error
                case ArtistSearchServiceResultFlag.Error:
                    OnError();
                    break;

                // Results Not Found
                case ArtistSearchServiceResultFlag.ResultsNotFound:
                    OnResultsNotFound();
                    break;

                // Results Found
                case ArtistSearchServiceResultFlag.ResultsFound:

                    // Display and populate grid
                    SearchResultsGridView.Visible = true;
                    SearchResultsGridView.DataSource = serviceResult.Results;
                    SearchResultsGridView.DataBind();

                    break;
            }
        }

        /// <summary>
        /// Events which take place when results of either the artist or album search come up empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnResultsNotFound()
        {
            // Hide the result grid, if already displayed from previous search
            SearchResultsGridView.Visible = false;
            NotFoundAlertDiv.Visible = true;
            ErrorDiv.Visible = false;
        }

        /// <summary>
        /// Events which take place when an error occurs
        /// </summary>
        protected void OnError()
        {
            NotFoundAlertDiv.Visible = false;
            SearchResultsGridView.Visible = false;
            ErrorDiv.Visible = true;
        }

    }
}