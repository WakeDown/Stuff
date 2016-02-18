using System;

namespace DALStuff.Models
{
    public partial class recruit_question_form_relatives
    {
        public int id { get; set; }
        public int id_question_form { get; set; }
        public string relation_degree { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public string birth_place { get; set; }
        public string work_place { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> dattim1 { get; set; }
    }
}
