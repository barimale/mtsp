using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using Google.OrTools.Sat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateVariablesStep : BaseStep, IEngineStep
    {
        public CreateVariablesStep()
            : base()
        {
            // intentionally left blank
        }

        protected int[] AllDestinations { get; set; }
        protected int[] AllPostmans { get; set; }
        protected Dictionary<Tuple<int, int>, IntVar> DestinationsForPostmans { get; set; }

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
            AllDestinations = Enumerable.Range(0, input.NumOfDestinations).ToArray();
            AllPostmans = Enumerable.Range(0, input.NumOfPostmans).ToArray();

            DestinationsForPostmans = new Dictionary<Tuple<int, int>, IntVar>();
            foreach (int n in AllDestinations)
            {
                foreach (int d in AllPostmans)
                {
                    DestinationsForPostmans.Add(Tuple.Create(n, d), _model.NewBoolVar($"destinations_n{n}d{d}"));
                }
            }
        }
    }
}
