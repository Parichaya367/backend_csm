using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class Csmproblem
    {
        public string CsmId { get; set; } = null!;
        public string FromUnitId { get; set; } = null!;
        public string FromTaskId { get; set; } = null!;
        public DateTime AvaiDate1 { get; set; }
        public DateTime AvaiDate2 { get; set; }
        public DateTime? AvaiDate3 { get; set; }
        public string NameReport { get; set; } = null!;
        public string PhoneNum { get; set; } = null!;

        public virtual AllTask FromTask { get; set; } = null!;
        public virtual Unit FromUnit { get; set; } = null!;
    }
}
