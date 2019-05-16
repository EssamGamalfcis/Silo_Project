using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class DocumentsType
    {
        public int DocId { get; set; }
        public string DocTypeName { get; set; }

        public virtual Documents Documents { get; set; }
    }
}
