using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class recruit_question_forms
    {
        public int id { get; set; }
        public string link_sid { get; set; }
        public int id_selection { get; set; }
        public int id_candidate { get; set; }
        public int id_vacancy { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public Nullable<bool> male { get; set; }
        public string display_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string nationality { get; set; }
        public string address { get; set; }
        public Nullable<bool> have_conviction { get; set; }
        public Nullable<bool> organization_owner { get; set; }
        public string have_owned_organization { get; set; }
        public Nullable<int> id_question_when_work { get; set; }
        public Nullable<bool> have_driver_license { get; set; }
        public Nullable<bool> have_car { get; set; }
        public string car_model { get; set; }
        public Nullable<int> driver_expirence { get; set; }
        public Nullable<int> id_question_marital_status { get; set; }
        public Nullable<int> id_position { get; set; }
        public string position_name { get; set; }
        public Nullable<decimal> minimum_salaty { get; set; }
        public Nullable<decimal> optimal_salary { get; set; }
        public Nullable<int> id_education { get; set; }
        public string science_degree { get; set; }
        public string computer_skills { get; set; }
        public Nullable<bool> have_trip_limit { get; set; }
        public Nullable<bool> have_health_limit { get; set; }
        public string free_time_rest { get; set; }
        public string life_attainment { get; set; }
        public string long_term_goal { get; set; }
        public string advantage { get; set; }
        public Nullable<System.DateTime> dattim1 { get; set; }
        public string client_ip { get; set; }
        public string client_user_agent { get; set; }
    }
}
