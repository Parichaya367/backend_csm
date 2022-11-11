using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class ProblemType
    {
        public ProblemType()
        {
            ProblemData = new HashSet<ProblemData>();
        }

        public string PtId { get; set; } = null!;
        public string? Probtype { get; set; }

        public virtual ICollection<ProblemData> ProblemData { get; set; }
    }
}