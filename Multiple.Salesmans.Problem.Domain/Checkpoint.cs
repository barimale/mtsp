using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Checkpoint
    {
        public Destination DestinationDetails { get; set; } = null!;
        public int Order { get; set; }
        public bool IsMainSpot => DestinationDetails.isMainSpot;
    }
}
