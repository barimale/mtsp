using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class PostpersonalizedWaypoint
    {
        public int PostPersonId { get; set; }
        public List<Waypoint> Waypoints { get; set; }
    }
}
