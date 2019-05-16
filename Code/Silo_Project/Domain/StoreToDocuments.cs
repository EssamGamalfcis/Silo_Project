using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class StoreToDocuments
    {
        public int StoreId { get; set; }
        public int DocId { get; set; }

        public virtual Documents Doc { get; set; }
        public virtual Store Store { get; set; }
    }
}
