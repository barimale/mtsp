﻿using TypeGen.Core.TypeAnnotations;

namespace MTSP.Domain
{
    [ExportTsInterface]
    public class PostPerson
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
