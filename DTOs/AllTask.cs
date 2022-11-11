using System;
using System.Collections.Generic;

namespace CSMAPI.DTOs
{
    public partial class AllTask
    {
        public string AlltaskId { get; set; } = null!;
        public string? FromSubtaskId1 { get; set; }
        public string? FromSubtaskId2 { get; set; }
        public string? FromSubtaskId3 { get; set; }
        public string? FromSubtaskId4 { get; set; }
        public string? FromSubtaskId5 { get; set; }
    }
}
