using Algorithm.MTSP.Domain;
using BingMapsRESTToolkit;
using DotNet.RestApi.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.MTSP.DistanceMatrixProviders
{
    internal class BingMapRouteProvider : IRouteProvider
    {
        private readonly RestApiClient _restApiClient;
        private string url;
        private string apiKey;

        public BingMapRouteProvider(RestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public void Initialize(string url, string apiKey)
        {
            this.url = url;
            this.apiKey = apiKey;
        }

        public async Task<List<Waypoint>> GetRoutes(List<Checkpoint> checkpoints)
        {
            UriBuilder baseUri = new UriBuilder(url);
            baseUri.Path += "/walking";

            var wayPointsToAppend = new StringBuilder();
            var wayPointEnumerator = 1;
            foreach (var checkpoint in checkpoints)
            {
                wayPointsToAppend.Append(@$"{TryGetSeparator(wayPointEnumerator)}{GetAlias(wayPointEnumerator)}.{wayPointEnumerator}={checkpoint.DestinationDetails.Longtitude},{checkpoint.DestinationDetails.Latitude}");
                wayPointEnumerator += 1;
            }
            wayPointsToAppend.Append(@$"&{GetAlias(1)}.{checkpoints.Count + 1}={checkpoints.First().DestinationDetails.Longtitude},{checkpoints.First().DestinationDetails.Latitude}");

            baseUri.Query += wayPointsToAppend.ToString();

            string optimizeModeToAppend = "&optimize=distance";
            baseUri.Query += optimizeModeToAppend;

            string apiKeyToAppend = $@"&key={apiKey}";
            baseUri.Query += apiKeyToAppend;

            var response = await _restApiClient.SendJsonRequest(HttpMethod.Get, baseUri.Uri, null);
            var result = await response.DeseriaseJsonResponseAsync<Response>();

            if (result.StatusCode != 200)
            {
                throw new Exception(string.Join(',', result.ErrorDetails));
            }

            var resultAsDynamic = await response.DeseriaseJsonResponseAsync<dynamic>();
            var results = resultAsDynamic.resourceSets[0].resources[0].results;

            var waypoints = new List<Waypoint>();
            foreach (dynamic item in results)
            {
                waypoints.Add(new Waypoint()
                {

                });
            }

            return waypoints;
        }

        private string TryGetSeparator(int index)
        {
            return index > 1 ? "&" : string.Empty;
        }

        private string GetAlias(int index)
        {
            return index == 1 ? "wp" : "vwp";
        }
    }
}
