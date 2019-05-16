using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Pages
    {
        public Pages()
        {
            RoleMenu = new HashSet<RoleMenu>();
        }

        public int PageId { get; set; }
        public int MenueId { get; set; }
        public string PageUrl { get; set; }
        public string PageName { get; set; }
        public int Priority { get; set; }

        public virtual Menus Menue { get; set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
    }
}
