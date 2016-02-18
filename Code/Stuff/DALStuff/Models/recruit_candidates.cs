using System;

namespace DALStuff.Models
{
    public partial class recruit_candidates
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string display_name { get; set; }
        public bool male { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public string creator_sid { get; set; }
        public int id_came_resource { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public string deleter_sid { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<int> id_came_type { get; set; }
    }
}
