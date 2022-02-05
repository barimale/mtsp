using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateConstraintsStep : CreateVariablesStep, IEngineStep
    {
        public CreateConstraintsStep()
            : base()
        {
            // intentionally left blank
        }

        public async virtual Task Initialize(InputData input)
        {
            try
            {
                await base.Initialize(input);

                CreateConstraints(input);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void CreateConstraints(InputData input)
        {
            try
            {
                //for (int i = 0; i < input.GifterAmount; ++i)
                //{
                //    Constraint constraint1 = _solver.MakeConstraint(0, 1, "");
                //    for (int j = 0; j < input.GifterAmount; ++j)
                //    {
                //        constraint1.SetCoefficient(variables[i, j], 1);
                //    }
                //}

                //for (int j = 0; j < input.GifterAmount; ++j)
                //{
                //    Constraint constraint2 = _solver.MakeConstraint(1, 1, "");
                //    for (int i = 0; i < input.GifterAmount; ++i)
                //    {
                //        constraint2.SetCoefficient(variables[i, j], 1);
                //    }
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
