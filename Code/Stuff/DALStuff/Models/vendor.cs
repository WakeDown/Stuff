using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class vendor
    {
        public int id { get; set; }
        public string name { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public string creator_sid { get; set; }
        public string deleter_sid { get; set; }
        public bool enabled { get; set; }
        public string descr { get; set; }
    }
}
