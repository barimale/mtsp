using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Waypoint
    {
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
    }
}
