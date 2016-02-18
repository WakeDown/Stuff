using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class recruit_question_links
    {
        public int id { get; set; }
        public int id_selection { get; set; }
        public System.Guid sid { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string creator_sid { get; set; }
        public System.DateTime dattim2 { get; set; }
        public string deleter_sid { get; set; }
    }
}
