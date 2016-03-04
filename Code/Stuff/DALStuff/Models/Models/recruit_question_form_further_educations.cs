using System;

namespace DALStuff.Models
{
    public partial class recruit_question_form_further_educations
    {
        public int id { get; set; }
        public string date_start { get; set; }
        public string duration { get; set; }
        public string place { get; set; }
        public string cource_name { get; set; }
        public int id_question_form { get; set; }
        public Nullable<System.DateTime> dattim1 { get; set; }
    }
}
