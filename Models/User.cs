using System;
using System.Collections.Generic;

namespace CSMAPI.Models
{
    public partial class User
    {
        public User()
        {
            Unit = new HashSet<Unit>();
        }

        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? PhoneNum { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
