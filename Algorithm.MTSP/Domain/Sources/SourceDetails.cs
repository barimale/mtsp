using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain.Sources
{
    // maybe better to use already existed class from nuget - need to check it
    [ExportTsInterface]
    public class SourceDetails
    {
        public string URL { get; set; }
        public AuthorizationType AuthorizationType { get; set; }
    }
}
