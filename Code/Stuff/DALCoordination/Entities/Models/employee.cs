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

        public int Id { get; set; }
        public string AdSid { get; set; }
        public int IdManager { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int IdPosition { get; set; }
        public int IdOrganization { get; set; }
        public string Email { get; set; }
        public string WorkNum { get; set; }
        public string MobilNum { get; set; }
        public short IdEmpState { get; set; }
        public int IdDepartment { get; set; }
        public int IdCity { get; set; }
        public bool Enabled { get; set; }
        public System.DateTime Dattim1 { get; set; }
        public System.DateTime Dattim2 { get; set; }
        public System.DateTime? DateCame { get; set; }
        public System.DateTime? BirthDate { get; set; }
        public bool Male { get; set; }
        public int IdPositionOrg { get; set; }
        public bool HasAdAccount { get; set; }
        public string CreatorSid { get; set; }
        public string AdLogin { get; set; }
        public System.DateTime? DateFired { get; set; }
        public string FullNameDat { get; set; }
        public string FullNameRod { get; set; }
        public bool NewvbieDelivery { get; set; }
        public int? IdBudget { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeReplaceds { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeAlternates { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<WfwDocumentExecution> WfwDocumentExecutions { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
