using System;

namespace DALStuff.Models
{
    public partial class rest_holidays
    {
        public int id { get; set; }
        public string employee_sid { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public int duration { get; set; }
        public bool can_edit { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public string creator_sid { get; set; }
        public string deleter_sid { get; set; }
        public bool enabled { get; set; }
        public Nullable<int> year { get; set; }
        public bool confirmed { get; set; }
        public string confirmator_sid { get; set; }
        public string can_edit_creator_sid { get; set; }
    }
}
