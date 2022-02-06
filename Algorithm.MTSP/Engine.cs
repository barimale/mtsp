using Algorithm.MTSP.DistanceMatrixProviders;
using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using Algorithm.MTSP.Steps;
using Google.OrTools.ConstraintSolver;
using Google.OrTools.Sat;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public sealed class Engine : CreateSearchParametersStep, IEngine
    {
        private readonly IMatrixDistanceProvider _matrixDistanceProvider;

        private string _matrixDistanceProviderUrl;
        private string _matrixDistanceProviderApiKey;

        public Engine(IMatrixDistanceProvider matrixDistanceProvider)
            : base()
        {
            _matrixDistanceProvider = matrixDistanceProvider;
        }

        public void Initialize(string matrixDistanceProviderUrl, string matrixDistanceProviderApiKey)
        {
            _matrixDistanceProviderUrl = matrixDistanceProviderUrl;
            _matrixDistanceProviderApiKey = matrixDistanceProviderApiKey;

            _matrixDistanceProvider.Initialize(
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

                return new OutputDataSummary()
                {
                    IsError = false,
                    Reason = string.Empty,
                    Data = OutputData.From(input, _model, _manager, solution)
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
