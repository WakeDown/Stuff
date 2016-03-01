using System;

namespace DAL.Entities.Models
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
        /// �����������
        /// </summary>
        public virtual Employee Alternate { get; set; }
        /// <summary>
        /// ���� ��������
        /// </summary>
        public virtual Employee Replaced { get; set; }
    }
}
