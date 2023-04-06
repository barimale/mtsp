using Algorithm.MTSP.Domain.Sources;

namespace Algorithm.MTSP.Domain.Factory
{
    public class SourcesFactory
    {
        public static SourceDetails CreateSource(string url, AuthorizationType authorizationType)
        {
            return new SourceDetails(url, authorizationType);
        }
    }
}
