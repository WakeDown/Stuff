using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Models
{
    public class EmployeeRole : EnabledEntity
    {
        public EmployeeRole()
        {
            this.WfwSchemeStages = new List<WfwSchemeStage>();
        }

        public string Name { get; set; }
        public string EmployeeSid { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<WfwSchemeStage> WfwSchemeStages { get; set; }
    }
}
