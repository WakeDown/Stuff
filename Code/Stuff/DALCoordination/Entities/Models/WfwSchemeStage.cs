namespace DALCoordination.Entities
{
    public class WfwSchemeStage : EnabledEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int? RoleId { get; set; }
        public string CoordinatorSid { get; set; }
        public int SchemeId { get; set; }
        public virtual EmployeeRole EmployeeRole { get; set; }
        public virtual WfwScheme WfwScheme { get; set; }
        public virtual Employee Coordinator { get; set; }

    }
}
