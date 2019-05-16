using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Documents
    {
        public Documents()
        {
            ItemToDocuments = new HashSet<ItemToDocuments>();
            SiloToDocuments = new HashSet<SiloToDocuments>();
            StoreToDocuments = new HashSet<StoreToDocuments>();
        }

        public int DocId { get; set; }
        public int? FromSiloId { get; set; }
        public int? ToSiloId { get; set; }
        public DateTime DocDate { get; set; }
        public string DocCode { get; set; }
        public int DocStatusFlag { get; set; }
        public string Notes { get; set; }

        public virtual Contract Doc { get; set; }
        public virtual DocumentsType DocNavigation { get; set; }
        public virtual ICollection<ItemToDocuments> ItemToDocuments { get; set; }
        public virtual ICollection<SiloToDocuments> SiloToDocuments { get; set; }
        public virtual ICollection<StoreToDocuments> StoreToDocuments { get; set; }
    }
}
