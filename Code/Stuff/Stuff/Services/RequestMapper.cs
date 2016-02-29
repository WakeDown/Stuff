using DALStuff.Models;

namespace Stuff.Services
{
    public class RequestMapper
    {
        public static Models.Request MapRequestToModel(request src, Models.Request dst = null)
        {
            if (src == null)
                return null;

            if (dst == null)
                dst = new Models.Request();

            dst.id = src.Id;
            dst.id_position = src.IdPosition;
            dst.position = src.Position != null ? src.Position.name : "";
            dst.id_reason = src.IdReason;
            dst.reason = src.RequestReason != null ? src.RequestReason.Name : "";
            dst.aim = src.Aim;
            dst.sid_manager = src.SidManager;
            dst.manager = src.ManagerPersom != null ? src.ManagerPersom.full_name : "";
            dst.sid_teacher = src.SidTeacher;
            dst.teacher = src.TeacherPerson != null ? src.TeacherPerson.full_name : "";
            dst.id_department = src.IdDepartment;
            dst.department = src.Department != null ? src.Department.name : "";
            dst.is_subordinates = src.IsSubordinates;
            dst.subordinates = src.Subordinates;
            dst.functions = src.Functions;
            dst.interactions = src.Interactions;
            dst.is_instructions = src.IsInstructions;
            dst.success_rates = src.SuccessRates;
            dst.plan_to_test = src.PlanToTest;
            dst.plan_after_test = src.PlanAfterTest;
            dst.work_place = src.WorkPlace;
            dst.work_mode = src.WorkMode;
            dst.holiday = src.Holiday;
            dst.hospital = src.Hospital;
            dst.business_trip = src.BusinessTrip;
            dst.overtime_work = src.OvertimeWork;
            dst.compensations = src.Compensations;
            dst.probation = src.Probation;
            dst.salary_to_test = src.SalaryToTest;
            dst.salary_after_test = src.SalaryAfterTest;
            dst.bonuses = src.Bonuses;
            dst.sex = src.Sex;
            dst.age_from = src.AgeFrom;
            dst.age_to = src.AgeTo;
            dst.education = src.Education;
            dst.last_work = src.LastWork;
            dst.requirements = src.Requirements;
            dst.knowledge = src.Knowledge;
            dst.suggestions = src.Suggestions;
            //dst.workplace = src.Workplace;
            dst.is_furniture = src.IsFurniture;
            dst.furniture = src.Furniture;
            dst.is_pc = src.IsPc;
            dst.is_telephone = src.IsTelephone;
            dst.is_ethalon = src.IsEthalon;
            dst.appearance = src.Appearance;
            dst.create_datetime = src.CreateDatetime;
            dst.last_change_datetime = src.LastChangeDatetime;
            dst.sid_contact_person = src.SidContactPerson;
            dst.contact_person = src.ContactPerson != null ? src.ContactPerson.full_name : "";
            dst.id_status = src.IdStatus;
            dst.status = src.RequestStatus != null ? src.RequestStatus.Name : "";
            dst.sid_responsible_person = src.SidResponsiblePerson;
            dst.responsible_person = src.ResponsiblePerson != null ? src.ResponsiblePerson.full_name : "";
            dst.IsCoordinationStarted = src.HaveCoordination;
            dst.enabled = src.Enabled;

            return dst;
        }

        public static request MapRequestToEntity(Models.Request src, request dst = null)
        {
            if (src == null)
                return null;

            if (dst == null)
                dst = new request();

            dst.Id  = src.id;
            dst.IdPosition  = src.id_position;
            dst.IdReason  = src.id_reason;
            dst.Aim  = src.aim;
            dst.SidManager  = src.sid_manager;
            dst.SidTeacher  = src.sid_teacher;
            dst.IdDepartment  = src.id_department;
            dst.IsSubordinates  = src.is_subordinates;
            dst.Subordinates  = src.subordinates;
            dst.Functions  = src.functions;
            dst.Interactions  = src.interactions;
            dst.IsInstructions  = src.is_instructions;
            dst.SuccessRates  = src.success_rates;
            dst.PlanToTest  = src.plan_to_test;
            dst.PlanAfterTest  = src.plan_after_test;
            dst.WorkPlace  = src.work_place;
            dst.WorkMode  = src.work_mode;
            dst.Holiday  = src.holiday;
            dst.Hospital  = src.hospital;
            dst.BusinessTrip  = src.business_trip;
            dst.OvertimeWork  = src.overtime_work;
            dst.Compensations  = src.compensations;
            dst.Probation  = src.probation;
            dst.SalaryToTest  = src.salary_to_test;
            dst.SalaryAfterTest  = src.salary_after_test;
            dst.Bonuses  = src.bonuses;
            dst.Sex  = src.sex;
            dst.AgeFrom  = src.age_from;
            dst.AgeTo  = src.age_to;
            dst.Education  = src.education;
            dst.LastWork  = src.last_work;
            dst.Requirements  = src.requirements;
            dst.Knowledge  = src.knowledge;
            dst.Suggestions  = src.suggestions;
            dst.IsFurniture  = src.is_furniture;
            dst.Furniture  = src.furniture;
            dst.IsPc  = src.is_pc;
            dst.IsTelephone  = src.is_telephone;
            dst.IsEthalon  = src.is_ethalon;
            dst.Appearance  = src.appearance;
            dst.CreateDatetime  = src.create_datetime;
            dst.LastChangeDatetime  = src.last_change_datetime;
            dst.SidContactPerson  = src.sid_contact_person;
            dst.IdStatus  = src.id_status;
            dst.SidResponsiblePerson  = src.sid_responsible_person;
            dst.HaveCoordination = src.IsCoordinationStarted;
            dst.Enabled  = src.enabled;

            return dst;
        }
    }
}