using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Store
    {
        public Store()
        {
            SiloToStore = new HashSet<SiloToStore>();
            StoreToCategory = new HashSet<StoreToCategory>();
            StoreToDocuments = new HashSet<StoreToDocuments>();
            StoreToItem = new HashSet<StoreToItem>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SiloToStore> SiloToStore { get; set; }
        public virtual ICollection<StoreToCategory> StoreToCategory { get; set; }
        public virtual ICollection<StoreToDocuments> StoreToDocuments { get; set; }
        public virtual ICollection<StoreToItem> StoreToItem { get; set; }
    }
}
