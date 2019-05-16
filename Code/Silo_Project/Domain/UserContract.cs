using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class UserContract
    {
        public int UserId { get; set; }
        public int DocId { get; set; }

        public virtual Contract Doc { get; set; }
        public virtual User User { get; set; }
    }
}
