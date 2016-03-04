using System;

namespace DALStuff.Models
{
    public partial class EmployeeAlternate
    {
        public EmployeeAlternate()
        {
            Enabled = true;
        }
        public int Id { get; set; }
        public string EmployeeSid { get; set; }
        public string AlternateEmployeeSid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Notify { get; set; }
        public bool? Unlimited { get; set; }
        public bool Enabled { get; set; }
        public virtual employee Alternate { get; set; }
        public virtual employee Replaced { get; set; }
    }
}
