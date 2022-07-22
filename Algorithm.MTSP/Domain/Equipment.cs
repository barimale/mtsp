using System.Globalization;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    public abstract class Equipment
    {
        public Dimensions Dimensions { get; set; }
        public abstract int GetCapacityInCubicCentimeters();
    }
}
