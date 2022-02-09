﻿using System.Collections.Generic;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class GiftEvent
    {
        public string Id { get; set; } = null!;
        public int OrginizerId { get; set; }
        public EventState State { get; set; }
        public IEnumerable<Participant> Participants { get; set; } = new List<Participant>();
    }
}