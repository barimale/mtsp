using BingMapsRESTToolkit;
using System.Collections.Generic;

namespace Algorithm.MTSP.Domain
{
    public class PostpersonalizedWaypoint
    {
        public int PostPersonId { get; set; }
        public List<Waypoint> Waypoints { get; set; }
    }
}
