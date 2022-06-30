namespace Algorithm.MTSP.Domain
{
    public static class DomainFactory
    {
        public SourcesFactory Sources { get;} = new SourcesFactory();
        public RoutesFactory Routes {get;} = new RoutesFactory();
    }
}
