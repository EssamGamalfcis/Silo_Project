using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class ItemWarehouse
    {
        public ItemWarehouse()
        {
            Item = new HashSet<Item>();
        }

        public int ItemWarehouseId { get; set; }
        public string ItemWarehouseName { get; set; }
        public string ItemWarehouseAddress { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
