using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class WfwEventResult : EnabledEntity
    {
        public WfwEventResult()
        {
            this.WfwExecutionEvents = new List<WfwExecutionEvent>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Success { get; set; }
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEvents { get; set; }
    }
}
