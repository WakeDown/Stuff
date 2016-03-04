using System;
using System.Collections.Generic;

namespace DALCoordination.Entities
{
    public partial class WfwDocumentWorkStages : EnabledEntity
    {
        public WfwDocumentWorkStages()
        {
            this.WfwExecutionEvents = new List<WfwExecutionEvent>();
        }

        public int ExecutionId { get; set; }
        public int Level { get; set; }
        public int? RoleId { get; set; }
        public string CoordinatorSid { get; set; }
        public DateTimeOffset? Date { get; set; }
        public int? ResultId { get; set; }
        public string Comment { get; set; }
        public virtual Employee Coordinator { get; set; }
        public virtual EmployeeRole EmployeeRole { get; set; }
        public virtual WfwEventResult WfwEventResult { get; set; }
        public virtual WfwDocumentExecution WfwDocumentExecution { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
