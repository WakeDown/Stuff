using System.Collections.Generic;

namespace DALCoordination.Entities
{
    public class WfwEventResult : EnabledEntity
    {
        public WfwEventResult()
        {
            this.WfwExecutionEvents = new List<WfwExecutionEvent>();
            this.WfwDocumentWorkStages = new List<WfwDocumentWorkStages>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Success { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
        public virtual ICollection<WfwDocumentWorkStages> WfwDocumentWorkStages { get; set; }
    }
}
