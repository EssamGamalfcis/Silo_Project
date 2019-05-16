using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Category
    {
        public Category()
        {
            Item = new HashSet<Item>();
            StoreToCategory = new HashSet<StoreToCategory>();
        }

        public int CatId { get; set; }
        public int StoreId { get; set; }
        public string CatName { get; set; }

        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<StoreToCategory> StoreToCategory { get; set; }
    }
}
