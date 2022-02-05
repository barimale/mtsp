using MTSP.Domain;
using System.Collections.Generic;

namespace Algorithm.MTSP.Model.Requests
{
    public class InputData
    {
        public CPSettings CPSettings { get; set; } = new CPSettings();
        public List<Destination> Destinations { get; set; } = new List<Destination>();
        public int NumOfDestinations => Destinations.Count;

        public List<PostPerson> Postpersons { get; set; } = new List<PostPerson>();

        public int NumOfPostmans => Postpersons.Count;
    }
}