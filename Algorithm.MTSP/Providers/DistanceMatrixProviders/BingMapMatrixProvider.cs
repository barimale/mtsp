using DotNet.RestApi.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Location = Algorithm.MTSP.Domain.Location;

namespace Algorithm.MTSP.DistanceMatrixProviders
{
    internal class BingMapProvider : IMatrixDistanceProvider
    {
        private readonly RestApiClient _restApiClient;
        private string url;
        private string apiKey;

        public BingMapProvider(RestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
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
            foreach (var destination in destinations)
            {
                originsToAppend.Append(@$"{destination.Latitude},{destination.Longtitude};");
            }
            originsToAppend.Remove(originsToAppend.Length - 1, 1);
            baseUri.Query = baseUri.Query + originsToAppend.ToString() + "&";

            var destinationsToAppend = new StringBuilder("destinations=");
            foreach (var destination in destinations)
            {
                destinationsToAppend.Append(@$"{destination.Latitude},{destination.Longtitude};");
            }
            destinationsToAppend.Remove(destinationsToAppend.Length - 1, 1);
            baseUri.Query = baseUri.Query + destinationsToAppend.ToString() + "&";

            string travelModeToAppend = "travelMode=walking";
            baseUri.Query = baseUri.Query + travelModeToAppend + "&";

            string apiKeyToAppend = $@"key={apiKey}";
            baseUri.Query = baseUri.Query + apiKeyToAppend;

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
