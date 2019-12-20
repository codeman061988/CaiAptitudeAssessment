using CaiAptitudeAssessment.Task2.Clients;
using CaiAptitudeAssessment.Task2.Interfaces;
using Flurl.Http.Configuration;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Unity;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using CaiAptitudeAssessment.Task2.Services;

namespace CaiAptitudeAssessment.Task2
{
    public class Global : HttpApplication
    {
        /// <summary>
        /// Code to run on application start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Start(object sender, EventArgs e)
        {
            var container  = this.AddUnity();

            container.RegisterType<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            container.RegisterType<ISpotifyClient, SpotifyClient>();
            container.RegisterType<IArtistSearchService, ArtistSearchService>();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}