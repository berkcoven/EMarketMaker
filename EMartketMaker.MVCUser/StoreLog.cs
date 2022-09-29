using System;
using System.Collections.Generic;

namespace EMartketMaker.MVCUser
{
    public partial class StoreLog
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Credits { get; set; }
        public string Reason { get; set; } = null!;
        public int Date { get; set; }
    }
}
