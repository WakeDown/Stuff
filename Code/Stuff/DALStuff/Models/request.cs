using System;

namespace DALStuff.Models
{
    // ReSharper disable once InconsistentNaming
    public class request
    {
        public int id { get; set; }
        public int? id_position { get; set; }
        public int? id_reason { get; set; }
        public string aim { get; set; }
        public int? id_manager { get; set; }
        public int? id_teacher { get; set; }
        public int? id_department { get; set; }
        public bool? is_subordinates { get; set; }
        public string subordinates { get; set; }
        public string functions { get; set; }
        public string interactions { get; set; }
        public bool? is_instructions { get; set; }
        public string success_rates { get; set; }
        public string plan_to_test { get; set; }
        public string plan_after_test { get; set; }
        public string work_place { get; set; }
        public string work_mode { get; set; }
        public string holiday { get; set; }
        public string hospital { get; set; }
        public string business_trip { get; set; }
        public string overtime_work { get; set; }
        public string compensations { get; set; }
        public int? probation { get; set; }
        public string salary_to_test { get; set; }
        public string salary_after_test { get; set; }
        public string bonuses { get; set; }
        public bool? sex { get; set; }
        public int? age_from { get; set; }
        public int? age_to { get; set; }
        public string education { get; set; }
        public string last_work { get; set; }
        public string requirements { get; set; }
        public string knowledge { get; set; }
        public string suggestions { get; set; }
        public string workplace { get; set; }
        public bool? is_furniture { get; set; }
        public string furniture { get; set; }
        public bool? is_pc { get; set; }
        public bool? is_telephone { get; set; }
        public bool? is_ethalon { get; set; }
        public DateTime? appearance { get; set; }
        public int? id_contact_person { get; set; }
        public int? id_responsible_person { get; set; }
        public bool Enabled { get; set; }
        public virtual department department { get; set; }
        public virtual employee contact_person { get; set; }
        public virtual employee manager_persom { get; set; }
        public virtual employee responsible_person { get; set; }
        public virtual employee teacher_person { get; set; }
        public virtual position position { get; set; }
        public virtual request_reason request_reason { get; set; }
    }
}
