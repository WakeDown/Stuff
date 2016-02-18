using System;

namespace DALStuff.Models
{
    public partial class holiday_work_confirms
    {
        public int id { get; set; }
        public string employee_sid { get; set; }
        public Nullable<int> id_hw_document { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string full_name { get; set; }
        public bool enabled { get; set; }
    }
}
