using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Csmproblem = new HashSet<Csmproblem>();
        }

        public string UnitId { get; set; } = null!;
        public string BelongToProj { get; set; } = null!;
        public string BelongToUser { get; set; } = null!;
        public string? Address { get; set; }

        public virtual Project BelongToProjNavigation { get; set; } = null!;
        public virtual User BelongToUserNavigation { get; set; } = null!;
        public virtual ICollection<Csmproblem> Csmproblem { get; set; }
    }
}
