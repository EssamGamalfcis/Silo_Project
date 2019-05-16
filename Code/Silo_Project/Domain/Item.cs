using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Item
    {
        public Item()
        {
            ItemToDocuments = new HashSet<ItemToDocuments>();
            StoreToItem = new HashSet<StoreToItem>();
        }

        public int ItemId { get; set; }
        public int CatId { get; set; }
        public int ItemWarehouseId { get; set; }
        public string ItemName { get; set; }
        public int ItemStartAmount { get; set; }
        public int ItemCurrnetAmount { get; set; }
        public int ItemPrice { get; set; }
        public string ItemDescription { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ItemAmountType ItemNavigation { get; set; }
        public virtual ItemWarehouse ItemWarehouse { get; set; }
        public virtual ICollection<ItemToDocuments> ItemToDocuments { get; set; }
        public virtual ICollection<StoreToItem> StoreToItem { get; set; }
    }
}
