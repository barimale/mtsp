using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateDemandCallbackStep : CreateTransitCallbackStep, IEngineStep
    {
        public CreateDemandCallbackStep()
            : base()
        {
            // intentionally left blank
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
            int demandCallbackIndex = _model.RegisterUnaryTransitCallback((long fromIndex) =>
            {
                // Convert from routing variable Index to
                // demand NodeIndex.
                var fromNode =
                    _manager.IndexToNode(fromIndex);
                return input.Demands[fromNode];
            });

            _model.AddDimensionWithVehicleCapacity(demandCallbackIndex, 0, // null capacity slack
                                                    input.VehicleCapacities, // vehicle maximum capacities
                                                    true,                   // start cumul to zero
                                                    "Capacity");
        }
    }
}
