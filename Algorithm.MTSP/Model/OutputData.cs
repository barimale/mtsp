using Google.OrTools.LinearSolver;
using Google.OrTools.Sat;

namespace Algorithm.MTSP.Model
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

        public Pair[] Pairs { get; set; }

        public int GifterAmount => Input.GifterAmount;
    }
}