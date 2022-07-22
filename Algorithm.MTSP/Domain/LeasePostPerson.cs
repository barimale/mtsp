using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class LeasePostPerson: PostPerson
    {
        public string Id { get; set; }
        public string HostPostCenterId = "";
    }
}
