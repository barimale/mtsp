using Algorithm.MTSP.Model.Requests;
using Google.OrTools.Sat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateVariablesStep : BaseStep, ICreateStep
    {
        protected CpSolver _solver;
        protected readonly CpModel _model;

        public CreateVariablesStep()
        {
            _model = new CpModel();
            _solver = new CpSolver();
        }

        public async virtual Task Initialize(InputData input)
        {
            try
            {
                await base.Initialize(input);

                CreateVariables(input);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateVariables(InputData input)
        {
            int[] allDestinations = Enumerable.Range(0, input.NumOfDestinations).ToArray();
            int[] allPostmans = Enumerable.Range(0, input.NumOfPostmans).ToArray();

            Dictionary<Tuple<int, int>, IntVar> destinationsForPostmans = new Dictionary<Tuple<int, int>, IntVar>();
            foreach (int n in allDestinations)
            {
                foreach (int d in allPostmans)
                {
                    destinationsForPostmans.Add(Tuple.Create(n, d), _model.NewBoolVar($"destinations_n{n}d{d}"));
                }
            }


        }
    }
}
