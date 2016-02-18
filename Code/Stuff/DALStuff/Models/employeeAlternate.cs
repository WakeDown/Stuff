using System;

namespace DALStuff.Models
{
    public partial class EmployeeAlternate
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int AlternateEmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Notify { get; set; }
        public bool? Unlimited { get; set; }
        public bool Enabled { get; set; }
        public virtual employee Alternate { get; set; }
        public virtual employee Replaced { get; set; }
    }
}
