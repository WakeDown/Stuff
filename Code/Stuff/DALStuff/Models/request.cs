using System;

namespace DALStuff.Models
{
    // ReSharper disable once InconsistentNaming
    public class request
    {
        public int Id { get; set; }
        public int? IdPosition { get; set; }
        public int? IdReason { get; set; }
        public string Aim { get; set; }
        public int? IdManager { get; set; }
        public int? IdTeacher { get; set; }
        public int? IdDepartment { get; set; }
        public bool? IsSubordinates { get; set; }
        public string Subordinates { get; set; }
        public string Functions { get; set; }
        public string Interactions { get; set; }
        public bool? IsInstructions { get; set; }
        public string SuccessRates { get; set; }
        public string PlanToTest { get; set; }
        public string PlanAfterTest { get; set; }
        public string WorkPlace { get; set; }
        public string WorkMode { get; set; }
        public string Holiday { get; set; }
        public string Hospital { get; set; }
        public string BusinessTrip { get; set; }
        public string OvertimeWork { get; set; }
        public string Compensations { get; set; }
        public int? Probation { get; set; }
        public string SalaryToTest { get; set; }
        public string SalaryAfterTest { get; set; }
        public string Bonuses { get; set; }
        public bool? Sex { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public string Education { get; set; }
        public string LastWork { get; set; }
        public string Requirements { get; set; }
        public string Knowledge { get; set; }
        public string Suggestions { get; set; }
        //public string Workplace { get; set; }
        public bool? IsFurniture { get; set; }
        public string Furniture { get; set; }
        public bool? IsPc { get; set; }
        public bool? IsTelephone { get; set; }
        public bool? IsEthalon { get; set; }
        public DateTime? Appearance { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? LastChangeDatetime { get; set; }
        public int? IdContactPerson { get; set; }
        public int? IdResponsiblePerson { get; set; }
        public int IdStatus { get; set; }
        public bool Enabled { get; set; }
        public virtual department Department { get; set; }
        public virtual employee ContactPerson { get; set; }
        public virtual employee ManagerPersom { get; set; }
        public virtual employee ResponsiblePerson { get; set; }
        public virtual employee TeacherPerson { get; set; }
        public virtual position Position { get; set; }
        public virtual RequestReason RequestReason { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
    }
}
