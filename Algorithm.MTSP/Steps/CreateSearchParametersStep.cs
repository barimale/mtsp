using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using Google.OrTools.ConstraintSolver;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateSearchParametersStep : CreateConstraintsStep, IEngineStep
    {
        private RoutingSearchParameters searchParameters;

        public CreateSearchParametersStep()
            : base()
        {
            // intentionally left blank
        }

        protected RoutingSearchParameters SearchParameters
        {
            get { return searchParameters; }
            private set { searchParameters = value; }
        }

        public async Task Initialize(InputData input)
        {
            try
            {
                await base.Initialize(input);

                CreateSearchParameters(input);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateSearchParameters(InputData input)
        {
            try
            {
                SearchParameters = operations_research_constraint_solver.DefaultRoutingSearchParameters();
                searchParameters.FirstSolutionStrategy = FirstSolutionStrategy.Types.Value.LocalCheapestArc;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
