using System;

namespace DALStuff.Models
{
    public partial class recruit_question_form_languages
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> expirence { get; set; }
        public string comment { get; set; }
        public int id_question_form { get; set; }
        public System.DateTime dattim1 { get; set; }
    }
}
