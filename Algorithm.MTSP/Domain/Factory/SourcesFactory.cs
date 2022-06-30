namespace Algorithm.MTSP.Domain.Factory
{
    public class SourcesFactory
    {
        public static SourceBuilder CreateSource()
        {
            return new SourceBuilder();
        }
    }
}
