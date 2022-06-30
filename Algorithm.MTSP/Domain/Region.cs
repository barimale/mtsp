using System.Collections;
using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class Region
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public IEnumerable<Checkpoint> Checkpoints{ get; set; } = new List<Checkpoint>();
    }
}
