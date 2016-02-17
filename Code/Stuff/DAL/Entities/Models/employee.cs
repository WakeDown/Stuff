using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeeReplaceds = new List<EmployeeAlternate>();
            this.EmployeeAlternates = new List<EmployeeAlternate>();
            this.EmployeeRoles = new List<EmployeeRole>();
            this.WfwDocumentExecutions = new List<WfwDocumentExecution>();
            this.WfwExecutionEvents = new List<WfwExecutionEvent>();
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
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public System.DateTime? date_came { get; set; }
        public System.DateTime? birth_date { get; set; }
        public bool male { get; set; }
        public int id_position_org { get; set; }
        public bool has_ad_account { get; set; }
        public string creator_sid { get; set; }
        public string ad_login { get; set; }
        public System.DateTime? date_fired { get; set; }
        public string full_name_dat { get; set; }
        public string full_name_rod { get; set; }
        public bool newvbie_delivery { get; set; }
        public int? id_budget { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeReplaceds { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeAlternates { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<WfwDocumentExecution> WfwDocumentExecutions { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
