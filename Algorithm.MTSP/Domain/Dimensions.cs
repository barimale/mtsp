using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Dimensions
    {
        public double WeightInGrams { get; set; }
        public double WidthInCentimeters { get; set; }
        public double HeightInCentimeters { get; set; }
        public double DepthInCentimeters { get; set; }
    }
}
