using System;
using System.Collections.Generic;

namespace DALCoordination.Entities
{
    public class EmployeeAlternate : EnabledEntity
    {
        public string EmployeeSid { get; set; }
        public string AlternateEmployeeSid { get; set; }
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
        public virtual ICollection<WfwExecutionEvent> WfwExecutionEventFormAlternate { get; set; }
    }
}
