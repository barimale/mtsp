using System.Collections;
using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class PostMainConfiguration
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public IEnumerable<Region> Regions { get; set; } = new List<Region>();
        public Location PostDepot {get; set;}
        public IEnumerable<PostPerson> PostPersons { get; set;} = new List<PostPerson>();
    }
}
