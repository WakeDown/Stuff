using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public class employee
    {
        public employee()
        {
            EmployeeReplaceds = new List<EmployeeAlternate>();
            EmployeeAlternates = new List<EmployeeAlternate>();
            EmployeeRoles = new List<EmployeeRole>();
            RequestsFromContactPersonRole = new List<request>();
            RequestsFromManagerRole = new List<request>();
            RequestsFromResponsibleRole = new List<request>();
            RequestsFromTeacherRole = new List<request>();
            RequestsCreated = new List<request>();
            request_history = new List<request_history>();
        }

        public int id { get; set; }
        public string ad_sid { get; set; }
        public int id_manager { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string full_name { get; set; }
        public string display_name { get; set; }
        public int id_position { get; set; }
        public int id_organization { get; set; }
        public string email { get; set; }
        public string work_num { get; set; }
        public string mobil_num { get; set; }
        public short id_emp_state { get; set; }
        public int id_department { get; set; }
        public int id_city { get; set; }
        public bool enabled { get; set; }
        public DateTime dattim1 { get; set; }
        public DateTime dattim2 { get; set; }
        public DateTime? date_came { get; set; }
        public DateTime? birth_date { get; set; }
        public bool male { get; set; }
        public int id_position_org { get; set; }
        public bool has_ad_account { get; set; }
        public string creator_sid { get; set; }
        public string ad_login { get; set; }
        public DateTime? date_fired { get; set; }
        public string full_name_dat { get; set; }
        public string full_name_rod { get; set; }
        public bool newvbie_delivery { get; set; }
        public int? id_budget { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeReplaceds { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeAlternates { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<request> RequestsFromContactPersonRole { get; set; }
        public virtual ICollection<request> RequestsFromManagerRole { get; set; }
        public virtual ICollection<request> RequestsFromResponsibleRole { get; set; }
        public virtual ICollection<request> RequestsFromTeacherRole { get; set; }
        public virtual ICollection<request> RequestsCreated { get; set; }
        public virtual ICollection<request_history> request_history { get; set; }
    }
}
