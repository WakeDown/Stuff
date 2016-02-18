using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class recruit_vacancies_view
    {
        public int id { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public string creator_sid { get; set; }
        public string author_sid { get; set; }
        public int id_position { get; set; }
        public int id_department { get; set; }
        public string chief_sid { get; set; }
        public int id_cause { get; set; }
        public string matcher_sid { get; set; }
        public string personal_manager_sid { get; set; }
        public Nullable<System.DateTime> deadline_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<int> id_state { get; set; }
        public Nullable<System.DateTime> state_change_date { get; set; }
        public string state_changer_sid { get; set; }
        public string deleter_sid { get; set; }
        public Nullable<System.DateTime> order_end_date { get; set; }
        public Nullable<System.DateTime> claim_end_date { get; set; }
        public Nullable<int> id_city { get; set; }
        public int id_branch_office { get; set; }
        public string creator_name { get; set; }
        public string author_name { get; set; }
        public string chief_name { get; set; }
        public string matcher_name { get; set; }
        public string personal_manager_name { get; set; }
        public string state_changer_name { get; set; }
        public string position_name { get; set; }
        public string department_name { get; set; }
        public string cause_name { get; set; }
        public string state_name { get; set; }
        public Nullable<int> candidate_total_count { get; set; }
        public Nullable<bool> state_is_active { get; set; }
        public Nullable<int> candidate_cancel_count { get; set; }
        public string state_background_color { get; set; }
        public string city_name { get; set; }
        public string branch_office_name { get; set; }
    }
}
