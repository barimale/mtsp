using System;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Delivery
    {
        public Dimensions Dimensions { get; set; }
        public int? Priority {get; set;} = null;
        public Location Destination {get; set;}
        public DateTimeOffset? DelliveryDate {get; set;} = null;
    }
}
