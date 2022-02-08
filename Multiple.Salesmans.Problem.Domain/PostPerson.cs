using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class PostPerson
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
