using System;
using System.Collections.Generic;

namespace EMartketMaker.MVCUser
{
    public partial class StoreMenu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ItemPrice { get; set; }
        public string ItemType { get; set; } = null!;
        public string ItemFlag { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string AdditionalInfo { get; set; } = null!;
        public bool ItemStatus { get; set; }
        public string SupportedGame { get; set; } = null!;
    }
}
