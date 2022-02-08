using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class Checkpoint
    {
        public int PostPersonId { get; set; }
        public Location? DestinationDetails { get; set; }
        public long Order { get; set; }
    }
}
