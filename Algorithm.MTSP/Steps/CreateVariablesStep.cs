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
            const int K = 1;
            const int U = 20;
            const int numOfDestinations = 4;
            const int numOfPostmans = 3;

            int[] allDestinations = Enumerable.Range(0, numOfDestinations).ToArray(); // WIP extend by type of building -> amount of people living there, use it later in line  29
            int[] allPostmans = Enumerable.Range(0, numOfPostmans).ToArray();

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
