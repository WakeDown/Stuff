using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitQuestionForm
    {
        /// <summary>
        /// Родственник
        /// </summary>
        public class Relative
        {
             public int Id { get; set; }
            public int IdQuestionForm { get; set; }
            public string RelationDegree { get; set; }
            public string Name { get; set; }
            public DateTime? BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string WorkPlace { get; set; }
            public string Address { get; set; }
        }
        /// <summary>
        /// Образование (основное)
        /// </summary>
        public class Education
        {
            public int Id { get; set; }
            public int IdQuestionForm { get; set; }
            public int YearStart { get; set; }
            public int YearEnd { get; set; }
            public string Place { get; set; }//Учебное заведение
            public string StudyType { get; set; }//Форма обучения
            public string Faculty { get; set; }
            public string Speciality { get; set; }
        }

        /// <summary>
        /// Доплонительное образование
        /// </summary>
        public class FurtherEducation
        {
            public int Id { get; set; }
            public int IdQuestionForm { get; set; }
            public string DateStart { get; set; }
            public string Duration { get; set; }
            public string Place { get; set; }
            public string CourceName { get; set; }
        }

        public class Language
        {
            public int Id { get; set; }
            public int IdQuestionForm { get; set; }
            public string Name { get; set; }
            public int Expirence { get; set; }
            public string Comment { get; set; }
        }

        public class Work
        {
            public int Id { get; set; }
            public int IdQuestionForm { get; set; }
            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string OrganizationName { get; set; }
            public string BusinessType { get; set; }
            public string Position { get; set; }
            public string Salary { get; set; }
            public string Subordinates { get; set; }
            public string Duties { get; set; }//Обязанности
            public string Achivements { get; set; }//Достижения
            public string SearchCause { get; set; }//Причина поиска
        }

        public class Fact
        {
            public int Id { get; set; }
            public int IdQuestionForm { get; set; }
            public string Name { get; set; }
            public int Rate { get; set; }
        }

        public int Id { get; set; }
        public int IdSelection { get; set; }
        public int IdVacancy { get; set; }
        public int IdCandidate { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string DisplayName { get; set; }
        public bool Male { get; set; }
        public string MaleStr => Male ? "Муж." : "Жен.";
        public DateTime? BirthDate { get; set; }
        public string BirthDateQueStr => BirthDate.HasValue ? BirthDate.Value.ToString("dd-MM-yyyy") : String.Empty;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public bool HaveConviction { get; set; }//Имеете ли судимость или увольнение по статье
        public bool OrganizationOwner { get; set; }//Являетесь ли владельцем предприятий
        public string HaveOwnedOrganization { get; set; }//Каких предприятий организатор
        public int IdQuestionWhenWork { get; set; }//Когда могли бы приступить к работе
        public bool HaveDriverLicense { get; set; }//Имеете ли водительское удостоверение
        public bool HaveCar { get; set; }//Наличие автомобиля
        public string CarModel { get; set; }//Марка автомобиля
        public int DriverExpirence { get; set; }//Водительский стаж
        public int IdQuestionMaritalStatus { get; set; }//Семейное положение
        public IEnumerable<Relative> RelativeList { get; set; } //Ближайшие родственники
        public int IdPosition { get; set; }//Претендую на должность
        public string PositionName { get; set; }
        public decimal MinimumSalaty { get; set; }//Минимальный уровень ЗП
        public decimal OptimalSalary { get; set; }//Оптимальный уровень ЗП
        public int IdEducation { get; set; }//Образование
        public string ScienceDegree { get; set; }//Научная степень
        public IEnumerable<Education> EducationList { get; set; }//Основное образование
        public IEnumerable<FurtherEducation> FurtherEducationList { get; set; }//Доплонительное образование
        public IEnumerable<Language> LanguageList { get; set; }
        public IEnumerable<Work> WorkList { get; set; }
        public string ComputerSkills { get; set; }//Навыки работы на компьютере
        public bool HaveTripLimit { get; set; }//Есть ли ограничения по командировкам
        public bool HaveHealthLimit { get; set; }//Есть ли ограничения по здоровью
        public string FreeTimeRest { get; set; }//Как проводите свободное время
        public string LifeAttainment { get; set; }//Самое больоше достижение в жизни
        public string LongTermGoal { get; set; }//Долгосрочная цель в профессии
        public string Advantage { get; set; }//Преимущество перед другими
        public IEnumerable<Fact> FactRate { get; set; } //Рейтинг обстоятельств
        public DateTime DateCreate { get; set; }
        public string ClientIp { get; set; }
        public string ClientUserAgent { get; set; }


        public RecruitQuestionForm()
        {
            
        }

        public RecruitQuestionForm(string sid)
        {
            SqlParameter psid = new SqlParameter() { ParameterName = "link_sid", SqlValue = sid, SqlDbType = SqlDbType.VarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_question_form_get", psid);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                FillSelf(row);
            }
        }

        //public RecruitQuestionForm(int id)
        //{
        //    //SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
        //    //var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_get", pId);
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    //var row = dt.Rows[0];
        //    //    //FillSelf(row);
        //    //}
        //}
        public RecruitQuestionForm(DataRow row)
            : this()
        {
            FillSelf(row);
        }

        private void FillSelf(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            IdSelection = Db.DbHelper.GetValueIntOrDefault(row, "id_selection");
            IdVacancy = Db.DbHelper.GetValueIntOrDefault(row, "id_vacancy");
            IdCandidate = Db.DbHelper.GetValueIntOrDefault(row, "id_candidate");
            Surname = Db.DbHelper.GetValueString(row, "surname");
            Name = Db.DbHelper.GetValueString(row, "name");
            Patronymic = Db.DbHelper.GetValueString(row, "patronymic");
            DisplayName = Db.DbHelper.GetValueString(row, "display_name");
            Male = Db.DbHelper.GetValueBool(row, "male");
            BirthDate = Db.DbHelper.GetValueDateTimeOrNull(row, "birth_date");
            Phone = Db.DbHelper.GetValueString(row, "phone");
            Email = Db.DbHelper.GetValueString(row, "email");
        }

        public static void Create(string sid)
        {
            SqlParameter pSid = new SqlParameter() { ParameterName = "link_sid", SqlValue = sid, SqlDbType = SqlDbType.VarChar };
            //SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_question_form_create", pSid);
            //int id = 0;
            //if (dt.Rows.Count > 0)
            //{
            //    int.TryParse(dt.Rows[0]["id"].ToString(), out id);
            //    Id = id;
            //}
        }

        public static string CreateLink(string creatorSid, int idSelection)
        {
            SqlParameter pidSelection = new SqlParameter() { ParameterName = "id_selection", SqlValue = idSelection, SqlDbType = SqlDbType.Int };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_question_create_link", pidSelection, pCreatorAdSid);
            //int id = 0;
            string sid = String.Empty;
            if (dt.Rows.Count > 0)
            {
                sid = Db.DbHelper.GetValueString(dt.Rows[0], "sid");
                //int.TryParse(dt.Rows[0]["id"].ToString(), out id);
                //Id = id;
            }
            return sid;
        }

        public static bool CheckLink(string sid)
        {
            SqlParameter pSid = new SqlParameter() { ParameterName = "sid", SqlValue = sid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_question_check_link", pSid);
            bool exists = false;
            if (dt.Rows.Count > 0)
            {
                exists = Db.DbHelper.GetValueBool(dt.Rows[0], "exists");
            }
            return exists;
        }
    }
}