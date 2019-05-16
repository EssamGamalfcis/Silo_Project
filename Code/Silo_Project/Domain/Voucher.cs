using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Voucher
    {
        public int DocId { get; set; }
        public string VoucherTypeName { get; set; }
        public DateTime VoucherDate { get; set; }
        public string Notes { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
