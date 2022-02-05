using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Checkpoint
    {
        public int PostPersonId { get; set; }
        public Destination DestinationDetails { get; set; } = null!;
        public int Order { get; set; }
    }
}
