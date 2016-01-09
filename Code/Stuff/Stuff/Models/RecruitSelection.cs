using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitSelection
    {
        public int Id { get; set; }
        public int IdVacancy { get; set; }
        public int IdCandidate { get; set; }
        public RecruitCandidate Candidate { get; set; }

        public int IdState { get; set; }
        public string StateName { get; set; }
        public bool ShowNextStateButton { get; set; }
        public string CreatorSid { get; set; }
        public string CreatorName { get; set; }
        public DateTime? StateChangeDate { get; set; }

        public string StateChangeDateStr=> StateChangeDate.HasValue ? StateChangeDate.Value.ToString("dd.MM.yyyy") : String.Empty;
        public string StateChangerSid { get; set; }
        public string StateChangerName { get; set; }
        public DateTime DateCreate { get; set; }
        public string StateDescr { get; set; }

        public int? IdNextState { get; set; }
        public string NextStateName { get; set; }
        public string NextStateButtonName { get; set; }
        public bool StateIsAccept { get; set; }


        public RecruitSelection()
        {
            Candidate = new RecruitCandidate();
        }
        public RecruitSelection(int id)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_get", pId);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                FillSelf(row);
            }
        }
        public RecruitSelection(DataRow row)
            : this()
        {
            FillSelf(row);
        }

        private void FillSelf(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            CreatorSid = Db.DbHelper.GetValueString(row, "creator_sid");
            CreatorName = Db.DbHelper.GetValueString(row, "creator_name");
            IdVacancy = Db.DbHelper.GetValueIntOrDefault(row, "id_vacancy");
            IdCandidate = Db.DbHelper.GetValueIntOrDefault(row, "id_candidate");
            IdState = Db.DbHelper.GetValueIntOrDefault(row, "id_state");
            StateName = Db.DbHelper.GetValueString(row, "state_name");
            StateChangeDate = Db.DbHelper.GetValueDateTimeOrNull(row, "state_change_date");
            StateChangerSid = Db.DbHelper.GetValueString(row, "state_changer_sid");
            StateChangerName = Db.DbHelper.GetValueString(row, "state_changer_name");
            DateCreate = Db.DbHelper.GetValueDateTimeOrDefault(row, "dattim1");
            IdNextState = Db.DbHelper.GetValueIntOrDefault(row, "next_state_id");
            NextStateName = Db.DbHelper.GetValueString(row, "next_state_name");
            StateDescr = Db.DbHelper.GetValueString(row, "state_descr");
            ShowNextStateButton = Db.DbHelper.GetValueBool(row, "show_next_state_btn");
            NextStateButtonName = Db.DbHelper.GetValueString(row, "next_state_btn_name");
            StateIsAccept = Db.DbHelper.GetValueBool(row, "state_is_accept");

            Candidate = new RecruitCandidate()
            {
                Id = IdCandidate,
                DisplayName = Db.DbHelper.GetValueString(row, "candidate_display_name"),
                BirthDate = Db.DbHelper.GetValueDateTimeOrNull(row, "candidate_birth_date"),
                Phone = Db.DbHelper.GetValueString(row, "candidate_phone"),
                Email = Db.DbHelper.GetValueString(row, "candidate_email"),
                Male = Db.DbHelper.GetValueBool(row, "candidate_male")
            };
        }

        public void Create(string creatorSid)
        {
            SqlParameter pIdVacancy = new SqlParameter() { ParameterName = "id_vacancy", SqlValue = IdVacancy, SqlDbType = SqlDbType.Int };
            SqlParameter pIdCandidate = new SqlParameter() { ParameterName = "id_candidate", SqlValue = IdCandidate, SqlDbType = SqlDbType.Int };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_create", pIdVacancy, pIdCandidate, pCreatorAdSid);
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                int.TryParse(dt.Rows[0]["id"].ToString(), out id);
                Id = id;
            }
        }

        public static IEnumerable<RecruitSelection> GetList(out int totalCount, int idVacancy)
        {
            
            SqlParameter pidVacancy = new SqlParameter() { ParameterName = "id_vacancy", SqlValue = idVacancy, SqlDbType = SqlDbType.Int };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_get_list", pidVacancy);

            totalCount = 0;
            var lst = new List<RecruitSelection>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var model = new RecruitSelection(row);
                    lst.Add(model);
                }
                totalCount = Db.DbHelper.GetValueIntOrDefault(dt.Rows[0], "total_count");
            }
            return lst;
        }

        public static void Close(int id, string deleterSid)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pDeleterSid = new SqlParameter() { ParameterName = "deleter_sid", SqlValue = deleterSid, SqlDbType = SqlDbType.VarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_close", pId, pDeleterSid);
        }

        public static void SetState(int id, string stateSysName, string creatorSid, string descr = null)
        {
            SqlParameter pid = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pstateSysName = new SqlParameter() { ParameterName = "state_sys_name", SqlValue = stateSysName, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pdescr = new SqlParameter() { ParameterName = "descr", SqlValue = descr, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_set_state", pid, pstateSysName, pCreatorAdSid, pdescr);
        }

        public static void SetState(int id, int idState, string creatorSid, string descr=null)
        {
            SqlParameter pid = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pidState = new SqlParameter() { ParameterName = "id_state", SqlValue = idState, SqlDbType = SqlDbType.Int };
            SqlParameter pdescr = new SqlParameter() { ParameterName = "descr", SqlValue = descr, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_set_state", pid, pidState, pCreatorAdSid, pdescr);
        }

        public static IEnumerable<HistoryItem> GetHistory(int id)
        {
            SqlParameter pid = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_selection_get_history", pid);

            var lst = new List<HistoryItem>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var model = new HistoryItem(row);
                    lst.Add(model);
                }
            }
            return lst;
        }
    }
}