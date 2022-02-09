using Algorithm.MTSP.Domain;
using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using Algorithm.MTSP.Providers.DistanceMatrixProviders;
using Algorithm.MTSP.Providers.RouteProviders;
using Algorithm.MTSP.Steps;
using Google.OrTools.ConstraintSolver;
using Google.OrTools.Sat;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public sealed class Engine : CreateSearchParametersStep, IEngine
    {
        private readonly IMatrixDistanceProvider _matrixDistanceProvider;
        private readonly IRouteProvider _routeProvider;

        private string _matrixDistanceProviderUrl;
        private string _matrixDistanceProviderApiKey;

        public Engine(IMatrixDistanceProvider matrixDistanceProvider, IRouteProvider routeProvider)
            : base()
        {
            _matrixDistanceProvider = matrixDistanceProvider;
            _routeProvider = routeProvider;
        }

        public void Initialize(string matrixDistanceProviderUrl, string matrixDistanceProviderApiKey)
        {
            _matrixDistanceProviderUrl = matrixDistanceProviderUrl;
            _matrixDistanceProviderApiKey = matrixDistanceProviderApiKey;

            _matrixDistanceProvider.Initialize(
                    _matrixDistanceProviderUrl,
                    _matrixDistanceProviderApiKey);

            _routeProvider.Initialize(
                _matrixDistanceProviderUrl,
                _matrixDistanceProviderApiKey);
        }

        public async Task<OutputDataSummary> CalculateAsync(InputData input)
        {
            try
            {
                input.DistanceMatrix = await _matrixDistanceProvider.CalculateDistanceMatrix(
                    input.Destinations
                        .ToList());

                await Initialize(input);

                Assignment solution = _model.SolveWithParameters(SearchParameters);

                var mappedData = OutputData.From(input, _model, _manager, solution);

                var checkpointsPerPostperson = mappedData
                    .Checkpoints
                    .GroupBy(p => p.PostPersonId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var waypointsPerPostperson = new ConcurrentBag<PostpersonalizedWaypoint>();

                await Task.WhenAll(checkpointsPerPostperson.Keys
                    .Select(async p =>
                    {
                        var waypoints = await _routeProvider.GetRoutes(checkpointsPerPostperson[p]);

                        waypointsPerPostperson.Add(new PostpersonalizedWaypoint()
                        {
                            PostPersonId = p,
                            Waypoints = waypoints
                        });
                    }).ToArray());

                return new OutputDataSummary()
                {
                    IsError = false,
                    Reason = string.Empty,
                    Data =
                    {
                        Status = mappedData.Status,
                        Input = mappedData.Input,
                        Checkpoints = mappedData.Checkpoints,
                        Waypoints = waypointsPerPostperson.ToList()
                    }
                };
            }
            catch (Exception ex)
            {
                return new OutputDataSummary()
                {
                    IsError = true,
                    Reason = ex.Message,
                    Data = new OutputData()
                    {
                        Status = CpSolverStatus.Unknown,
                        Input = input,
                    }
                };
            }
        }
    }
}
