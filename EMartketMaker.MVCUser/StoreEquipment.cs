using System;
using System.Collections.Generic;

namespace EMartketMaker.MVCUser
{
    public partial class StoreEquipment
    {
        public int PlayerId { get; set; }
        public string Type { get; set; } = null!;
        public string UniqueId { get; set; } = null!;
        public int Slot { get; set; }
    }
}
