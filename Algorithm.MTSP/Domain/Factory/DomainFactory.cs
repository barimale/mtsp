namespace Algorithm.MTSP.Domain.Factory
{
    public class DomainFactory
    {
        public SourcesFactory Sources { get;} = new SourcesFactory();
        public RoutesFactory Routes {get;} = new RoutesFactory();
    }
}
