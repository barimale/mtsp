using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Checkpoint
    {
        public int PostPersonId { get; set; }
        public Location DestinationDetails { get; set; } = null;
        public long Order { get; set; }
    }
}
