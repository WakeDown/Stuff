using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class recruit_vacancy_causes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sys_name { get; set; }
        public int order_num { get; set; }
        public bool enabled { get; set; }
    }
}
