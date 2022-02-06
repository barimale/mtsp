using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Destination
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public bool isMainSpot { get; set; } = false;
    }
}
