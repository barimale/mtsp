using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using Algorithm.MTSP.Steps;
using Google.OrTools.ConstraintSolver;
using Google.OrTools.Sat;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public sealed class Engine : CreateSearchParametersStep
    {
        public Engine()
            : base()
        {
            // intentionally left blank
        }

        public async Task<OutputDataSummary> CalculateAsync(InputData input)
        {
            try
            {
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
