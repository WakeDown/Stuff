using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class document
    {
        public int id { get; set; }
        public System.Guid data_sid { get; set; }
        public byte[] summary { get; set; }
        public byte[] data { get; set; }
        public string name { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public string creator_sid { get; set; }
        public string deleter_sid { get; set; }
    }
}
