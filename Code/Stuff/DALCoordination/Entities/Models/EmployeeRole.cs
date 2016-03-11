using System.Collections.Generic;

namespace DALCoordination.Entities
{
    public class EmployeeRole : EnabledEntity
    {
        public EmployeeRole()
        {
            this.WfwSchemeStages = new List<WfwSchemeStage>();
            this.WfwDocumentWorkSchemes = new List<WfwDocumentWorkStages>();

        }

        public string Name { get; set; }
        public string EmployeeSid { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<WfwSchemeStage> WfwSchemeStages { get; set; }
        public virtual ICollection<WfwDocumentWorkStages> WfwDocumentWorkSchemes { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEventsFromRole { get; set; }
    }
}
