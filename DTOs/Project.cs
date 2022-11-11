using System;
using System.Collections.Generic;

namespace CSMAPI.DTOs
{
    public partial class Project
    {
        public Project()
        {
            Unit = new HashSet<CSMAPI.Models.Unit>();
        }

        public string ProjId { get; set; } = null!;
        public string ProjName { get; set; } = null!;

        public virtual ICollection<CSMAPI.Models.Unit> Unit { get; set; }
    }
}
