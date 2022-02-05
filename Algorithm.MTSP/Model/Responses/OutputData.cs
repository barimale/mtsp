using Algorithm.MTSP.Model.Requests;
using Google.OrTools.Sat;
using MTSP.Domain;
using System.Collections.Generic;
using System.Linq;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Responses
{
    [ExportTsInterface]
    public class OutputData
    {
        public CpSolverStatus Status;
        public InputData Input { get; set; }
        public List<Checkpoint> Checkpoints { get; set; }
        public int CalculatedAmountOfCheckpoints => Input.Destinations.Count(p => !p.isMainSpot) + (2 * Input.NumOfPostmans);
    }
}