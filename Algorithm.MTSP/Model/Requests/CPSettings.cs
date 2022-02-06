using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Requests
{
    [ExportTsInterface]
    public class CPSettings
    {
        public int GlobalSpanCostCoefficient { get; set; } = 100;
        public long Capacity { get; set; } = 3000;
        public long SlackMax { get; set; } = 0;
    }
}