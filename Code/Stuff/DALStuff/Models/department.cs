using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class department
    {
        public department()
        {
            this.requests = new List<request>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public int id_parent { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public int id_chief { get; set; }
        public string creator_sid { get; set; }
        public bool hidden { get; set; }
        public string sys_name { get; set; }
        public virtual ICollection<request> requests { get; set; }
    }
}
