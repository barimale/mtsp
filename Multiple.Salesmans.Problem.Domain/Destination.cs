using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Destination
    {
        public string Name { get; set; }
        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public bool isMainSpot { get; set; }
    }
}
