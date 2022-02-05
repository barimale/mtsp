using Google.OrTools.Sat;

namespace Algorithm.MTSP.Steps
{
    public class BaseStep
    {
        protected readonly CpSolver _solver;
        protected readonly CpModel _model;

        public BaseStep()
        {
            _model = new CpModel();
            _solver = new CpSolver();
        }
    }
}
