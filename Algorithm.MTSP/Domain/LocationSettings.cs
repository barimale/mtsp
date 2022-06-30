using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class LocationSettings
    {
        public int AverageServiceDurationInSeconds { get; set; }
    }
}
