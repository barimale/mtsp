namespace Algorithm.MTSP.Domain
{
    public static class DomainFactory
    {
        public static SourceBuilder CreateSource()
        {
            return new SourceBuilder();
        }
    }
}
