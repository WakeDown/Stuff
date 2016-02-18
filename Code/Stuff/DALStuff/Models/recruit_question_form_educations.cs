using System;

namespace DALStuff.Models
{
    public partial class recruit_question_form_educations
    {
        public int id { get; set; }
        public int id_question_form { get; set; }
        public System.DateTime dattim1 { get; set; }
        public Nullable<int> year_start { get; set; }
        public Nullable<int> year_end { get; set; }
        public string place { get; set; }
        public string study_type { get; set; }
        public string faculty { get; set; }
        public string speciality { get; set; }
    }
}
