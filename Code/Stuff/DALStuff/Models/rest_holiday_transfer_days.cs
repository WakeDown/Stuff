using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class rest_holiday_transfer_days
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string descr { get; set; }
        public string creator_sid { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public Nullable<System.DateTime> dattim2 { get; set; }
        public string deleter_sid { get; set; }
    }
}
