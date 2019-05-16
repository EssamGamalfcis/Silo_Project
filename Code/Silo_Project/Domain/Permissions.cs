using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Permissions
    {
        public Permissions()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }

        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
