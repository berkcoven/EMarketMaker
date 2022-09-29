using System;
using System.Collections.Generic;

namespace EMartketMaker.MVCUser
{
    public partial class StorePlayer
    {
        public int Id { get; set; }
        public string Authid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        public int DateOfJoin { get; set; }
        public int DateOfLastJoin { get; set; }
    }
}
