using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class recruit_vacancy_state_history
    {
        public int id { get; set; }
        public int id_vacancy { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string creator_sid { get; set; }
        public int id_state { get; set; }
        public string descr { get; set; }
    }
}
