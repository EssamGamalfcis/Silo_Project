using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class SiloToStore
    {
        public int SiloId { get; set; }
        public int StoreId { get; set; }

        public virtual Silo Silo { get; set; }
        public virtual Store Store { get; set; }
    }
}
