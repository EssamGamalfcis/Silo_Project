using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class StoreToItem
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
