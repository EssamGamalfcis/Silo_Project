using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Menus
    {
        public Menus()
        {
            Pages = new HashSet<Pages>();
        }

        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public int Priority { get; set; }

        public virtual ICollection<Pages> Pages { get; set; }
    }
}
