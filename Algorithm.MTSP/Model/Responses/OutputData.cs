using Algorithm.MTSP.Model.Requests;
using Google.OrTools.Sat;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Responses
{
    [ExportTsInterface]
    public class OutputData
    {
        public CpSolverStatus Status;

        public InputData Input { get; set; }
    }
}