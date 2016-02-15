using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class employee : EnabledEntity
    {
        public employee()
        {
            this.EmployeeReplaceds = new List<EmployeeAlternate>();
            this.EmployeeAlternates = new List<EmployeeAlternate>();
            this.EmployeeRoles = new List<EmployeeRole>();
            this.WfwDocumentExecutions = new List<WfwDocumentExecution>();
            this.WfwExecutionEvents = new List<WfwExecutionEvent>();
        }

        public string Name { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeReplaceds { get; set; }
        public virtual ICollection<EmployeeAlternate> EmployeeAlternates { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<WfwDocumentExecution> WfwDocumentExecutions { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
