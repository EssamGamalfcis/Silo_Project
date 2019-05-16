using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Contract
    {
        public Contract()
        {
            UserContract = new HashSet<UserContract>();
        }

        public int DocId { get; set; }
        public string ContractCode { get; set; }
        public string Classification { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual Voucher Doc { get; set; }
        public virtual Documents Documents { get; set; }
        public virtual ICollection<UserContract> UserContract { get; set; }
    }
}
