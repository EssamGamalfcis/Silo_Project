using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Silo
    {
        public Silo()
        {
            SiloToDocuments = new HashSet<SiloToDocuments>();
            SiloToStore = new HashSet<SiloToStore>();
            User = new HashSet<User>();
        }

        public int SiloId { get; set; }
        public string SiloName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<SiloToDocuments> SiloToDocuments { get; set; }
        public virtual ICollection<SiloToStore> SiloToStore { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
