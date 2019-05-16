using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class ItemAmountType
    {
        public int ItemId { get; set; }
        public string AmountTypeDescription { get; set; }

        public virtual Item Item { get; set; }
    }
}
