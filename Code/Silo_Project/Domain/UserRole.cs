using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual User User { get; set; }
    }
}
