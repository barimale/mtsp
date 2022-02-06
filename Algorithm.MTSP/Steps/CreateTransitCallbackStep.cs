using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateTransitCallbackStep : BaseStep, IEngineStep
    {
        private int transitCallbackIndex;

        public CreateTransitCallbackStep()
            : base()
        {
            // intentionally left blank
        }

        protected int TransitCallbackIndex
        {
            get { return transitCallbackIndex; }
            private set { transitCallbackIndex = value; }
        }

        public async virtual Task Initialize(InputData input)
        {
            try
            {
                await base.Initialize(input);

                CreateDistanceHandler(input);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateDistanceHandler(InputData input)
        {
            // Create and register a transit callback.
            TransitCallbackIndex = _model.RegisterTransitCallback((long fromIndex, long toIndex) =>
            {
                // Convert from routing variable Index to distance matrix NodeIndex.
                var fromNode = _manager.IndexToNode(fromIndex);
                var toNode = _manager.IndexToNode(toIndex);
                return input.DistanceMatrix()[fromNode, toNode];
            });

            // Define cost of each arc.
            _model.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);
        }
    }
}
