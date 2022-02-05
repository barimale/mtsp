using Algorithm.MTSP.Model.Requests;
using Google.OrTools.Sat;

namespace Algorithm.MTSP.Model.Responses
{
    public class OutputData
    {
        public CpSolverStatus Status;

        public InputData Input { get; set; }
    }
}