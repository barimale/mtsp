using DotNet.RestApi.Client;
using MTSP.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            this.url = url;
            this.apiKey = apiKey;
        }

        public async Task<long[,]> CalculateDistanceMatrix(Location origin, List<Location> destinations)
        {
            UriBuilder baseUri = new UriBuilder(url);
            baseUri.Query = baseUri.Query + "?";

            string originToAppend = "origins={" + $@"{origin.Latitude},{origin.Longtitude}" + "}";
            baseUri.Query = baseUri.Query + originToAppend + "&";

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
            var result = await response.DeseriaseJsonResponseAsync<dynamic[]>();

            return new long[4, 2];
        }
    }
}
