using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using Algorithm.MTSP.Steps;
using Google.OrTools.Sat;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public sealed class Engine : CreateObjectiveFunctionStep
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

                CpSolverStatus resultStatus = _solver.Solve(_model);

                return new OutputDataSummary()
                {
                    IsError = resultStatus != CpSolverStatus.Optimal && resultStatus != CpSolverStatus.Feasible ? true : false,
                    Reason = string.Empty,
                    Data = new OutputData()
                    {
                        Status = resultStatus,
                        Variables = Variables,
                        Input = input,
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

        //private Pair[] ToPairs(Solver.ResultStatus status, Variable[,] variables, int gifterAmount)
        //{
        //    var result = new List<Pair>();

        //    if (status == Solver.ResultStatus.OPTIMAL || status == Solver.ResultStatus.FEASIBLE)
        //    {
        //        for (int i = 0; i < gifterAmount; ++i)
        //        {
        //            for (int j = 0; j < gifterAmount; ++j)
        //            {
        //                if (variables[i, j].SolutionValue() > 0.5)
        //                {
        //                    result.Add(
        //                        new Pair()
        //                        {
        //                            FromIndex = i,
        //                            ToIndex = j
        //                        });
        //                }
        //            }
        //        }
        //    }

        //    return result.ToArray();
        //}
    }
}
