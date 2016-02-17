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

        public int Stage { get; set; }
        public System.DateTime StartDate { get; set; }
        public int CreaterId { get; set; }
        public System.DateTime EndDate { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual Employee employee { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
