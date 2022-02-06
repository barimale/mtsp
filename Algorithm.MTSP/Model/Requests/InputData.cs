using MTSP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Requests
{
    [ExportTsInterface]
    public class InputData
    {
        public CPSettings CPSettings { get; set; } = new CPSettings();
        public List<Destination> Destinations { get; set; } = new List<Destination>();
        public int NumOfDestinations => Destinations.Count;
        public List<PostPerson> Postpersons { get; set; } = new List<PostPerson>();
        public int NumOfPostmans => Postpersons.Count;
        public int Depot => Destinations.Single(p => p.isMainSpot).Index;

        public long[,] DistanceMatrix()
        {
            return new long[1, 1];
        }

        internal Destination Single()
        {
            throw new NotImplementedException();
        }
    }
}