using System;

namespace DALStuff.Models
{
    public partial class recruit_question_form_facts
    {
        public int id { get; set; }
        public int id_question_form { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string name { get; set; }
        public Nullable<int> rate { get; set; }
    }
}
