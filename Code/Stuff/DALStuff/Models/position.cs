using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class position
    {
        public position()
        {
            this.requests = new List<request>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public int order_num { get; set; }
        public string creator_sid { get; set; }
        public string name_rod { get; set; }
        public string name_dat { get; set; }
        public string sys_name { get; set; }
        public virtual ICollection<request> requests { get; set; }
    }
}
