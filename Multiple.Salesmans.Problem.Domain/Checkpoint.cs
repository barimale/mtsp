using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Checkpoint
    {
        public string PostPersonId { get; set; }
        public Location? DestinationDetails { get; set; } = null!;
        public long Order { get; set; }
    }
}
