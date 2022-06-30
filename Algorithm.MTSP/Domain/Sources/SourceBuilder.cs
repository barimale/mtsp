namespace Algorithm.MTSP.Domain.Sources
{
    public class SourceBuilder
    {
        private string url;
        private AuthorizationType authorizationType;

        public SourceDetails WithUrl(string url)
        {
            this.url = url;

            return this;
        }

        public SourceDetails WithAuthorizationType(AuthorizationType authorizationType)
        {
            this.authorizationType = authorizationType;
            
            return this;
        }

        public SourceDetails Build()
        {
            return new SourceDetails(
                this.url,
                this.authorizationType
            );
        }
    }
}
