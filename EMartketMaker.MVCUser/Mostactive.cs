using System;
using System.Collections.Generic;

namespace EMartketMaker.MVCUser
{
    public partial class Mostactive
    {
        public string Playername { get; set; } = null!;
        public string Steamid { get; set; } = null!;
        public int LastAccountuse { get; set; }
        public int? TimeCt { get; set; }
        public int? TimeTt { get; set; }
        public int? TimeSpe { get; set; }
        public int? TimeWa { get; set; }
        public int? Total { get; set; }
    }
}
