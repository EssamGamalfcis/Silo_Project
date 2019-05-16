using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class SiloToDocuments
    {
        public int SiloId { get; set; }
        public int DocId { get; set; }

        public virtual Documents Doc { get; set; }
        public virtual Silo Silo { get; set; }
    }
}
