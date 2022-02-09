using Algorithm.MTSP.Domain;
using BingMapsRESTToolkit;
using DotNet.RestApi.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Waypoint = Algorithm.MTSP.Domain.Waypoint;

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
            try
            {
                UriBuilder baseUri = new UriBuilder(url);
                baseUri.Path += "/walking";

                var wayPointsToAppend = new StringBuilder();
                var wayPointEnumerator = 1;
                foreach (var checkpoint in checkpoints)
                {
                    wayPointsToAppend.Append(@$"{TryGetSeparator(wayPointEnumerator)}{GetAlias(wayPointEnumerator)}.{wayPointEnumerator}={checkpoint.DestinationDetails.Latitude},{checkpoint.DestinationDetails.Longtitude}");
                    wayPointEnumerator += 1;
                }
                wayPointsToAppend.Append(@$"&{GetAlias(1)}.{checkpoints.Count + 1}={checkpoints.First().DestinationDetails.Latitude},{checkpoints.First().DestinationDetails.Longtitude}");

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
                string json = await response.Content.ReadAsStringAsync();
                var resourceSets = resultAsDynamic.resourceSets[0] as dynamic;
                var resource = resourceSets.resources[0] as dynamic;
                Route route = JsonConvert.DeserializeObject<Route>(resource.ToString());

                var waypoints = new List<Waypoint>();
                foreach (var item in route.RouteLegs)
                {
                    foreach (var subleg in item.RouteSubLegs)
                    {
                        waypoints.Add(new Waypoint()
                        {
                            Latitude = subleg.StartWaypoint.Coordinates[0],
                            Longtitude = subleg.StartWaypoint.Coordinates[1],

                        });
                        waypoints.Add(new Waypoint()
                        {
                            Latitude = subleg.EndWaypoint.Coordinates[0],
                            Longtitude = subleg.EndWaypoint.Coordinates[1],
                        });
                    }
                }

                return waypoints.Distinct().ToList();
            }
            catch (Exception)
            {
                return new List<Waypoint>();
            }
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
