using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using Google.OrTools.ConstraintSolver;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class BaseStep : IEngineStep
    {
        protected RoutingModel _model;
        protected RoutingIndexManager _manager;

        public BaseStep()
        {
            // intentionally left blank
        }

        protected CPSettings CPSettings { get; private set; }

        public async virtual Task Initialize(InputData input)
        {
            try
            {
                CPSettings = input.CPSettings;
                _manager = new RoutingIndexManager(
                    input.NumOfDestinations,
                    input.NumOfPostmans,
                    input.Depot);

                _model = new RoutingModel(_manager);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
