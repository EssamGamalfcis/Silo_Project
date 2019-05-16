using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class User
    {
        public User()
        {
            UserContract = new HashSet<UserContract>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public int SiloId { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public decimal UserPhone { get; set; }

        public virtual Silo Silo { get; set; }
        public virtual ICollection<UserContract> UserContract { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
