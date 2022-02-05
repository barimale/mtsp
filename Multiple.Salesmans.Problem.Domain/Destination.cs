using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Destination
    {
        public int Longtitude { get; set; }
        public int Latitude { get; set; }
        public bool isMainSpot { get; set; } = false;
    }
}
