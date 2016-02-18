using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class recruit_selections
    {
        public int id { get; set; }
        public int id_candidate { get; set; }
        public int id_vacancy { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public string creator_sid { get; set; }
        public string deleter_sid { get; set; }
        public Nullable<int> id_state { get; set; }
        public Nullable<System.DateTime> state_change_date { get; set; }
        public string state_changer_sid { get; set; }
        public string state_descr { get; set; }
        public Nullable<int> id_came_type { get; set; }
    }
}
