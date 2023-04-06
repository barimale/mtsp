using DotNet.RestApi.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Location = Algorithm.MTSP.Domain.Location;

namespace Algorithm.MTSP.Providers.DistanceMatrixProviders
{
    internal class BingMapProvider : IMatrixDistanceProvider
    {
        private readonly NumberFormatInfo nfi = new NumberFormatInfo();

        private readonly RestApiClient _restApiClient;
        private string url;
        private string apiKey;

        public BingMapProvider(RestApiClient restApiClient)
        {
            _restApiClient = restApiClient;

            nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
        }

        public void Initialize(string url, string apiKey)
        {
            UriBuilder baseUri = new(url);
            baseUri.Path += "/DistanceMatrix";

            this.url = baseUri.Uri.ToString();
            this.apiKey = apiKey;
        }

        public async Task<long[,]> CalculateDistanceMatrix(List<Location> destinations)
        {
            UriBuilder baseUri = new UriBuilder(url);
            baseUri.Query = baseUri.Query + "?";

            var originsToAppend = new StringBuilder("origins=");
            foreach (var destination in destinations.Where(p => p.isMainSpot))
            {
                originsToAppend.Append(@$"{destination.Latitude.ToString(nfi)},{destination.Longtitude.ToString(nfi)};");
            }
            originsToAppend.Remove(originsToAppend.Length - 1, 1);
            baseUri.Query = baseUri.Query + originsToAppend.ToString() + "&";

            var destinationsToAppend = new StringBuilder("destinations=");
            foreach (var destination in destinations.Where(p => !p.isMainSpot))
            {
                destinationsToAppend.Append(@$"{destination.Latitude.ToString(nfi)},{destination.Longtitude.ToString(nfi)};");
            }
            destinationsToAppend.Remove(destinationsToAppend.Length - 1, 1);
            baseUri.Query = baseUri.Query + destinationsToAppend.ToString() + "&";

            string travelModeToAppend = "travelMode=walking";
            baseUri.Query = baseUri.Query + travelModeToAppend + "&";

            string apiKeyToAppend = $@"key={apiKey}";
            baseUri.Query = baseUri.Query + apiKeyToAppend;

            // TODO maybe replace it as described below:
            // https://learn.microsoft.com/en-us/bingmaps/rest-services/routes/calculate-a-distance-matrix
            var response = await _restApiClient.SendJsonRequest(HttpMethod.Get, baseUri.Uri, null);
            var result = await response.DeseriaseJsonResponseAsync<dynamic>();
            var results = result.resourceSets[0].resources[0].results;

            var output = new long[destinations.Count, destinations.Count];
            foreach (dynamic item in results)
            {
                output[item.originIndex, item.destinationIndex] = item.travelDuration;
                output[item.destinationIndex, item.originIndex] = item.travelDuration;
            }

            return output;
        }
    }
}
