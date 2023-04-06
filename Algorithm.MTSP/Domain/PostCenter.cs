using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class PostCenter: Location
    {
        public bool isMainSpot => true;
        public IEnumerable<Equipment> Equipments { get; set;} = new List<Equipment>();
        public IEnumerable<PostPerson> Workers { get; set;} = new List<PostPerson>();
        public IEnumerable<Region> Districts { get; set;} = new List<Region>();
    }
}