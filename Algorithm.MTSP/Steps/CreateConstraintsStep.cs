using Algorithm.MTSP.Abstractions;
using Algorithm.MTSP.Model.Requests;
using Google.OrTools.ConstraintSolver;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class CreateConstraintsStep : CreateDemandCallbackStep, IEngineStep
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
                _model.AddDimension(
                    TransitCallbackIndex,
                    CPSettings.SlackMax,
                    CPSettings.Capacity,
                    true,
                    "Distance");

                RoutingDimension distanceDimension = _model.GetMutableDimension("Distance");
                distanceDimension.SetGlobalSpanCostCoefficient(CPSettings.GlobalSpanCostCoefficient);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
