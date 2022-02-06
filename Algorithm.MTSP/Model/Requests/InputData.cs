using MTSP.Domain;
using System.Collections.Generic;
using System.Linq;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Requests
{
    [ExportTsInterface]
    public class InputData
    {
        public CPSettings CPSettings { get; set; } = new CPSettings();
        public List<Location> Destinations { get; set; } = new List<Location>();
        public int NumOfDestinations => Destinations.Count;
        public List<PostPerson> Postpersons { get; set; } = new List<PostPerson>();
        public int NumOfPostmans => Postpersons.Count;
        public Location Origin => Destinations.Single(p => p.isMainSpot);
        public int Depot => Origin.Index;
        public long[,] DistanceMatrix { get; set; }
    }
}