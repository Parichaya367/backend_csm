using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class ProblemData
    {
        public ProblemData()
        {
            SubTask1 = new HashSet<SubTask1>();
            SubTask2 = new HashSet<SubTask2>();
            SubTask3 = new HashSet<SubTask3>();
            SubTask4 = new HashSet<SubTask4>();
            SubTask5 = new HashSet<SubTask5>();
        }

        public string PdId { get; set; } = null!;
        public string? PdDesc { get; set; }
        public string? PtId { get; set; }

        public virtual ProblemType? Pt { get; set; }
        public virtual ICollection<SubTask1> SubTask1 { get; set; }
        public virtual ICollection<SubTask2> SubTask2 { get; set; }
        public virtual ICollection<SubTask3> SubTask3 { get; set; }
        public virtual ICollection<SubTask4> SubTask4 { get; set; }
        public virtual ICollection<SubTask5> SubTask5 { get; set; }
    }
}
