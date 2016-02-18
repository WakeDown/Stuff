using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class employee_rest_holidays_report
    {
        public string department { get; set; }
        public string employee { get; set; }
        public Nullable<int> year { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public int duration { get; set; }
        public System.DateTime date_create { get; set; }
        public bool can_edit { get; set; }
        public bool confirmed { get; set; }
        public string confimator { get; set; }
    }
}
