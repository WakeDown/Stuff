using System.Collections.Generic;

namespace DAL.Entities.Models
{
    public class EmployeeRole : EnabledEntity
    {
        public EmployeeRole()
        {
            this.WfwSchemeStages = new List<WfwSchemeStage>();
        }

        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<WfwSchemeStage> WfwSchemeStages { get; set; }
    }
}
