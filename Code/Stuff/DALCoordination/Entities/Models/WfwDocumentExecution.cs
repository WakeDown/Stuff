using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class WfwDocumentExecution : EnabledEntity
    {
        public WfwDocumentExecution()
        {
            this.Documents = new List<Document>();
            this.WfwExecutionEvents = new List<WfwExecutionEvent>();
        }

        public int Level { get; set; }
        public System.DateTime StartDate { get; set; }
        public string CreaterSid { get; set; }
        public System.DateTime? EndDate { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual Employee CreatorEmployee { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
