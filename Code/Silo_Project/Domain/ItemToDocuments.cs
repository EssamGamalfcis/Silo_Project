using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class ItemToDocuments
    {
        public int ItemId { get; set; }
        public int DocId { get; set; }

        public virtual Documents Doc { get; set; }
        public virtual Item Item { get; set; }
    }
}
