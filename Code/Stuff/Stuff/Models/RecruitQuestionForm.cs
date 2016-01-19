using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitQuestionForm
    {
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