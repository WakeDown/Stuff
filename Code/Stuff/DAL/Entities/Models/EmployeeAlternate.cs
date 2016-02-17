using System;

namespace DAL.Entities.Models
{
    public class EmployeeAlternate : EnabledEntity
    {
        public int EmployeeId { get; set; }
        public int AlternateEmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Notify { get; set; }
        public bool? Unlimited { get; set; }
        /// <summary>
        /// Заместитель
        /// </summary>
        public virtual Employee Alternate { get; set; }
        /// <summary>
        /// Кого замещают
        /// </summary>
        public virtual Employee Replaced { get; set; }
    }
}
