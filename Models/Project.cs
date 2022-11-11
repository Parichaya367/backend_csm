using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            Unit = new HashSet<Unit>();
        }

        public string ProjId { get; set; } = null!;
        public string ProjName { get; set; } = null!;

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
