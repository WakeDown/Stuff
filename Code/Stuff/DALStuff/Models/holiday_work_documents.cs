using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class holiday_work_documents
    {
        public int id { get; set; }
        public System.DateTime dattim1 { get; set; }
        public bool enabled { get; set; }
        public System.DateTime date_start { get; set; }
        public System.DateTime date_end { get; set; }
        public string creator_sid { get; set; }
    }
}
