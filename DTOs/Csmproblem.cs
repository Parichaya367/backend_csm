using System;
using System.Collections.Generic;

namespace CSMAPI.DTOs
{
    public partial class Csmproblem
    {
        public string FromUnitId { get; set; } = null!;
        public DateTime AvaiDate1 { get; set; }
        public DateTime AvaiDate2 { get; set; }
        public DateTime? AvaiDate3 { get; set; }
        public string NameReport { get; set; } = null!;
        public string PhoneNum { get; set; } = null!;
    }
}
