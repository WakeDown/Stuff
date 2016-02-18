using System;

namespace DALStuff.Models
{
    public partial class recruit_question_form_works
    {
        public int id { get; set; }
        public int id_question_form { get; set; }
        public System.DateTime dattim1 { get; set; }
        public Nullable<System.DateTime> date_start { get; set; }
        public Nullable<System.DateTime> date_end { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string organization_name { get; set; }
        public string business_type { get; set; }
        public string position { get; set; }
        public Nullable<decimal> salary { get; set; }
        public string subordinates { get; set; }
        public string duties { get; set; }
        public string achivements { get; set; }
        public string search_cause { get; set; }
    }
}
