using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Requests
{
    [ExportTsInterface]
    public class CPSettings
    {
        public int K { get; set; } = 1;
        public int U { get; set; } = 20;
    }
}