using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain.Sources
{
    // maybe better to use already existed class from nuget - need to check it
    // maybe public only assuming that it has to be reused later on at the UI level.
    [ExportTsInterface]
    protected internal class SourceDetails
    {
        protected internal SourceDetails(string url, AuthorizationType authorizationType)
        {
            this.URL = url;
            this.AuthorizationType = authorizationType;
        }

        protected internal string URL { public get; set; }
        protected internal AuthorizationType AuthorizationType { public get; set; }
    }
}
