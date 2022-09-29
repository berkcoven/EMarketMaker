using System;
using System.Collections.Generic;

namespace EMartketMaker.MVCUser
{
    public partial class StoreItem
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Type { get; set; } = null!;
        public string UniqueId { get; set; } = null!;
        public int DateOfPurchase { get; set; }
        public int DateOfExpiration { get; set; }
        public int? PriceOfPurchase { get; set; }
    }
}
