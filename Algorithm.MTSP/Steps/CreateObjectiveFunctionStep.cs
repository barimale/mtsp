using Algorithm.MTSP.Model.Requests;
using Google.OrTools.LinearSolver;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateObjectiveFunctionStep : CreateConstraintsStep, ICreateStep
    {
        public CreateObjectiveFunctionStep()
            : base()
        {
            // intentionally left blank
        }

        public async Task Initialize(InputData input)
        {
            try
            {
                await base.Initialize(input);

                CreateObjectiveFunction(input, Variables);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateObjectiveFunction(InputData input, Variable[,] variables)
        {
            try
            {
                Objective objective = _solver.Objective();

                for (int i = 0; i < input.GifterAmount; ++i)
                {
                    for (int j = 0; j < input.GifterAmount; ++j)
                    {
                        objective.SetCoefficient(variables[i, j], input.Costs[i, j]);
                    }
                }

                objective.SetMinimization();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
