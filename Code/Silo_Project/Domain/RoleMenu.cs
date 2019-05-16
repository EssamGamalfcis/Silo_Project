using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class RoleMenu
    {
        public int PageId { get; set; }
        public int RoleId { get; set; }

        public virtual Pages Page { get; set; }
        public virtual Roles Role { get; set; }
    }
}
