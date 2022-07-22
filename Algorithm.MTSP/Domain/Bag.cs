using System.Globalization;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Bag: Equipment
    {
        public Dimensions Dimensions { get; set; }
        public string OwnerId {get; set;}
        public string PostCenterId {get; set;}
        public override int GetCapacityInCubicCentimeters()
        {
            // remember to calculate it based on Dimensions or remove it at all
            return 0;
        }
    }
}
