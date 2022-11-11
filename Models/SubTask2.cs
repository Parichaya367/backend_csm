using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class SubTask2
    {
        public SubTask2()
        {
            AllTask = new HashSet<AllTask>();
        }

        public string SubtaskId { get; set; } = null!;
        public string Pbcode { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }

        public virtual ProblemData PbcodeNavigation { get; set; } = null!;
        public virtual ICollection<AllTask> AllTask { get; set; }
    }
}