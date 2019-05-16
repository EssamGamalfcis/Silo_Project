using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class StoreToCategory
    {
        public int StoreId { get; set; }
        public int CatId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual Store Store { get; set; }
    }
}
