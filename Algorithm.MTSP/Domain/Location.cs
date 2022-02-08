using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Location
    {
        public int Index { get; set; }
        public string Name { get; set; } = "";
        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public bool isMainSpot { get; set; } = false;
    }
}
