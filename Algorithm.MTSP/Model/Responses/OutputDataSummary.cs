using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Responses
{
    [ExportTsInterface]
    public class OutputDataSummary
    {
        public bool IsError { get; set; } = false;
        public string Reason { get; set; }
        public OutputData Data { get; set; }
    }
}
