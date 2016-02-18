using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class employeeAlternate
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public int alternateEmployeeId { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public bool notify { get; set; }
        public Nullable<bool> unlimited { get; set; }
        public bool enabled { get; set; }
        public virtual employee employee { get; set; }
        public virtual employee employee1 { get; set; }
    }
}
