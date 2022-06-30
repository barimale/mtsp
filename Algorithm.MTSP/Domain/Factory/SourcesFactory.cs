namespace Algorithm.MTSP.Domain.Factory
{
    public static class SourcesFactory
    {
        public static SourceBuilder CreateSource()
        {
            return new SourceBuilder();
        }
    }
}
