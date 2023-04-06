using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain.Sources
{
    // maybe better to use already existed class from nuget - need to check it
    // maybe public only assuming that it has to be reused later on at the UI level.
    [ExportTsInterface]
    public class SourceDetails
    {
        public SourceDetails(string url, AuthorizationType authorizationType)
        {
            this.URL = url;
            this.AuthorizationType = authorizationType;
        }

        public string URL { get; set; }
        public AuthorizationType AuthorizationType { get; set; }
    }

    [ExportTsInterface]
    public class AuthorizationType
    {
        // it needs to be modified as described above
    }
}
