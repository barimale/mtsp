using Algorithm.MTSP.Model.Requests;
using Google.OrTools.Sat;
using System;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Steps
{
    public class BaseStep
    {
        protected readonly CpSolver _solver;
        protected readonly CpModel _model;
        protected dynamic bag;

        public BaseStep()
        {
            _model = new CpModel();
            _solver = new CpSolver();
        }

        protected CPSettings CPSettings { get; private set; }

        public async virtual Task Initialize(InputData input)
        {
            try
            {
                CPSettings = input.CPSettings;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
