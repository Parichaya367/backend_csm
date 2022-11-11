using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class AllTask
    {
        public AllTask()
        {
            Csmproblem = new HashSet<Csmproblem>();
        }

        public string AlltaskId { get; set; } = null!;
        public string? FromSubtask1Id { get; set; }
        public string? FromSubtask2Id { get; set; }
        public string? FromSubtask3Id { get; set; }
        public string? FromSubtask4Id { get; set; }
        public string? FromSubtask5Id { get; set; }

        public virtual SubTask1? FromSubtask1 { get; set; }
        public virtual SubTask2? FromSubtask2 { get; set; }
        public virtual SubTask3? FromSubtask3 { get; set; }
        public virtual SubTask4? FromSubtask4 { get; set; }
        public virtual SubTask5? FromSubtask5 { get; set; }
        public virtual ICollection<Csmproblem> Csmproblem { get; set; }
    }
}
