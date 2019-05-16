using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Roles
    {
        public Roles()
        {
            RoleMenu = new HashSet<RoleMenu>();
            RolePermission = new HashSet<RolePermission>();
            UserRole = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
