using System;
using System.Collections.Generic;

namespace CSMAPI.DTOs
{
    public partial class Unit
    {
        // public Unit()
        // {
        //     Csmproblem = new HashSet<CSMAPI.Models.Csmproblem>();
        // }

        public string UnitId { get; set; } = null!;
        public string BelongToProj { get; set; } = null!;
        public string BelongToUser { get; set; } = null!;
        public string? Address { get; set; }

        // public virtual ICollection<CSMAPI.Models.Csmproblem> Csmproblem { get; set; }
    }
}
