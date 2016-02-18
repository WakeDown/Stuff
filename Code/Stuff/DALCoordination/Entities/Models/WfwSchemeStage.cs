using System;

namespace DAL.Entities.Models
{
    public class WfwSchemeStage : EnabledEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int? RoleId { get; set; }
        public int? CoordinatorId { get; set; }
        public int SchemeId { get; set; }
        public virtual EmployeeRole EmployeeRole { get; set; }
        public virtual WfwScheme WfwScheme { get; set; }
    }
}
