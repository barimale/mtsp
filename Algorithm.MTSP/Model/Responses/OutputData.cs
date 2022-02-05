using Algorithm.MTSP.Model.Requests;
using Google.OrTools.LinearSolver;
using Google.OrTools.Sat;

namespace Algorithm.MTSP.Model.Responses
{
    public class OutputData
    {
        private Variable[,] variables;

        public CpSolverStatus Status;

        public InputData Input { get; set; }

        public Variable[,] Variables
        {
            get
            {
                return variables;
            }
            set
            {
                variables = value;
            }
        }
    }
}