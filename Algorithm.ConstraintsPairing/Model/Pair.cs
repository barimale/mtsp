using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model
{
    [ExportTsInterface]
    public class Pair
    {
        public int FromIndex { get; set; }
        public int ToIndex { get; set; }
    }
}
