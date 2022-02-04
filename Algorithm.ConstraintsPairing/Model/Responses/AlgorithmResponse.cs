using Algorithm.MTSP.Model;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Responses
{
    [ExportTsInterface]
    public class AlgorithmResponse
    {
        public bool IsError { get; set; } = false;
        public string Reason { get; set; }
        public Pair[] Pairs { get; set; }
        public string AnalysisStatus { get; set; }
    }
}
