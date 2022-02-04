using Algorithm.MTSP.Model;
using Google.OrTools.LinearSolver;
using Google.OrTools.Sat;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public class CreateVariablesStep : ICreateStep
    {
        protected CpSolver _solver;
        protected readonly CpModel _model;

        public CreateVariablesStep()
        {
            _model = new CpModel();
            _solver = new CpSolver();
        }

        public Variable[,] Variables { get; private set; }

        public async virtual Task Initialize(InputData input)
        {
            try
            {
                Variables = CreateVariables(input);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Variable[,] CreateVariables(InputData input)
        {
            Variable[,] x = new Variable[input.GifterAmount, input.GifterAmount];
            for (int i = 0; i < input.GifterAmount; ++i)
            {
                for (int j = 0; j < input.GifterAmount; ++j)
                {
                    if (i == j)
                    {
                        x[i, j] = _solver.MakeIntVar(0, 0, $"No assignment to yourself");
                    }
                    else if (input.Costs[i, j] == 100)
                    {
                        x[i, j] = _solver.MakeIntVar(0, 0, $"No assignment when the participant is excluded");
                    }
                    else
                    {
                        x[i, j] = _solver.MakeIntVar(0, 1, $"gifter_{i}_participant_{j}");
                    }
                }
            }

            return x;
        }
    }
}
