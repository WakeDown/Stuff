using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class branch_offices
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool enabled { get; set; }
        public int order_num { get; set; }
    }
}
