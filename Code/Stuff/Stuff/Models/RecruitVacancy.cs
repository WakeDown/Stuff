using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Http.Routing;
using DataProvider.Helpers;
using Stuff.Helpers;

namespace Stuff.Models
{
    public class RecruitVacancy
    {
        public int Id { get; set; }
        public string CreatorSid { get; set; }
        public string CreatorName { get; set; }
        public string AuthorSid { get; set; }
        public string AuthorName { get; set; }
        public int IdPosition { get; set; }
        public string PositionName { get; set; }
        public int IdDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string ChiefSid { get; set; }
        public string ChiefName { get; set; }
        public int IdCause { get; set; }
        public string CauseName { get; set; }
        public string MatcherSid { get; set; }
        public string MatcherName { get; set; }
        public string PersonalManagerSid { get; set; }
        public string PersonalManagerName { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IdState { get; set; }
        public string StateName { get; set; }
        public DateTime? StateChangeDate { get; set; }
        public string StateChangerSid { get; set; }
        public string StateChangerName { get; set; }
        public DateTime DateCreate { get; set; }
        public int CandidateTotalCount { get; set; }
        public int CandidateCancelCount { get; set; }
        //public int CandidateAcceptCount { get; set; }
        public bool StateIsActive { get; set; }
        public string StateBackgroundColor { get; set; }
        public string StateChangeDateStr
            => StateChangeDate.HasValue ? StateChangeDate.Value.ToString("dd.MM.yyyy") : String.Empty;
        public string DateCreateStr => DateCreate.ToString("dd.MM.yyyy");
        public DateTime? OrderEndDate { get; set; }
        public DateTime? ClaimEndDate { get; set; }
        public int? IdCity { get; set; }
        public string CityName { get; set; }
        public int IdBranchOffice { get; set; }
        public string BranchOfficeName { get; set; }

        public RecruitVacancy()
        {
            
        }

        public RecruitVacancy(int id, string viewerSid = null)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pViewerSid = new SqlParameter() { ParameterName = "viewer_sid", SqlValue = viewerSid, SqlDbType = SqlDbType.VarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_get", pId, pViewerSid);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                FillSelf(row);
            }
        }

        public RecruitVacancy(DataRow row)
            : this()
        {
            FillSelf(row);
        }

        private void FillSelf(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            CreatorSid = Db.DbHelper.GetValueString(row, "creator_sid");
            CreatorName = Db.DbHelper.GetValueString(row, "creator_name");
            AuthorSid = Db.DbHelper.GetValueString(row, "author_sid");
            AuthorName = Db.DbHelper.GetValueString(row, "author_name");
            IdPosition = Db.DbHelper.GetValueIntOrDefault(row, "id_position");
            PositionName = Db.DbHelper.GetValueString(row, "position_name");
            IdDepartment = Db.DbHelper.GetValueIntOrDefault(row, "id_department");
            DepartmentName = Db.DbHelper.GetValueString(row, "department_name");
            ChiefSid = Db.DbHelper.GetValueString(row, "chief_sid");
            ChiefName = Db.DbHelper.GetValueString(row, "chief_name");
            IdCause = Db.DbHelper.GetValueIntOrDefault(row, "id_cause");
            CauseName = Db.DbHelper.GetValueString(row, "cause_name");
            MatcherSid = Db.DbHelper.GetValueString(row, "matcher_sid");
            MatcherName = Db.DbHelper.GetValueString(row, "matcher_name");
            PersonalManagerSid = Db.DbHelper.GetValueString(row, "personal_manager_sid");
            PersonalManagerName = Db.DbHelper.GetValueString(row, "personal_manager_name");
            DeadlineDate = Db.DbHelper.GetValueDateTimeOrNull(row, "deadline_date");
            EndDate = Db.DbHelper.GetValueDateTimeOrNull(row, "end_date");
            IdState = Db.DbHelper.GetValueIntOrDefault(row, "id_state");
            StateName = Db.DbHelper.GetValueString(row, "state_name");
            StateChangeDate = Db.DbHelper.GetValueDateTimeOrNull(row, "state_change_date");
            StateChangerSid = Db.DbHelper.GetValueString(row, "state_changer_sid");
            StateChangerName = Db.DbHelper.GetValueString(row, "state_changer_name");
            DateCreate = Db.DbHelper.GetValueDateTimeOrDefault(row, "dattim1");
            CandidateTotalCount = Db.DbHelper.GetValueIntOrDefault(row, "candidate_total_count");
            CandidateCancelCount = Db.DbHelper.GetValueIntOrDefault(row, "candidate_cancel_count");
            //CandidateAcceptCount = Db.DbHelper.GetValueIntOrDefault(row, "candidate_accept_count");
            StateBackgroundColor = Db.DbHelper.GetValueString(row, "state_background_color");
            StateIsActive = Db.DbHelper.GetValueBool(row, "state_is_active");
            OrderEndDate= Db.DbHelper.GetValueDateTimeOrNull(row, "order_end_date");
            ClaimEndDate = Db.DbHelper.GetValueDateTimeOrNull(row, "claim_end_date");
            IdCity = Db.DbHelper.GetValueIntOrNull(row, "id_city");
            CityName = Db.DbHelper.GetValueString(row, "city_name");
            IdBranchOffice = Db.DbHelper.GetValueIntOrDefault(row, "id_branch_office");
            BranchOfficeName = Db.DbHelper.GetValueString(row, "branch_office_name");
        }

        public void Create(string creatorSid)
        {
            SqlParameter pAuthorSid = new SqlParameter() { ParameterName = "author_sid", SqlValue = AuthorSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pIdPosition = new SqlParameter() { ParameterName = "id_position", SqlValue = IdPosition, SqlDbType = SqlDbType.Int };
            SqlParameter pIdDepartment = new SqlParameter() { ParameterName = "id_department", SqlValue = IdDepartment, SqlDbType = SqlDbType.Int };
            SqlParameter pChiefSid = new SqlParameter() { ParameterName = "chief_sid", SqlValue = ChiefSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pIdCause = new SqlParameter() { ParameterName = "id_cause", SqlValue = IdCause, SqlDbType = SqlDbType.Int };
            SqlParameter pMatcherSid = new SqlParameter() { ParameterName = "matcher_sid", SqlValue = MatcherSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pPersonalManagerSid = new SqlParameter() { ParameterName = "personal_manager_sid", SqlValue = PersonalManagerSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pDeadlineDate = new SqlParameter() { ParameterName = "deadline_date", SqlValue = DeadlineDate, SqlDbType = SqlDbType.DateTime };
            SqlParameter pOrderEndDate = new SqlParameter() { ParameterName = "order_end_date", SqlValue = OrderEndDate, SqlDbType = SqlDbType.Date };
            SqlParameter pClaimEndDate = new SqlParameter() { ParameterName = "claim_end_date", SqlValue = ClaimEndDate, SqlDbType = SqlDbType.Date };
            //SqlParameter pEndDate = new SqlParameter() { ParameterName = "end_date", SqlValue = EndDate, SqlDbType = SqlDbType.DateTime };
            //SqlParameter pIdState = new SqlParameter() { ParameterName = "id_state", SqlValue = IdState, SqlDbType = SqlDbType.Int };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pIdCity = new SqlParameter() { ParameterName = "id_city", SqlValue = IdCity, SqlDbType = SqlDbType.Int };
            SqlParameter pIdBranchOffice = new SqlParameter() { ParameterName = "id_branch_office", SqlValue = IdBranchOffice, SqlDbType = SqlDbType.Int };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_create", pAuthorSid, pIdPosition, pIdDepartment, pChiefSid, pIdCause, pMatcherSid, pPersonalManagerSid, pDeadlineDate, pCreatorAdSid, pOrderEndDate, pClaimEndDate, pIdCity, pIdBranchOffice);
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                int.TryParse(dt.Rows[0]["id"].ToString(), out id);
                Id = id;
            }

            //Если создал не менеджер по персоналу вакансии, то уведомляем его
            if (!creatorSid.Equals(PersonalManagerSid) && !String.IsNullOrEmpty(PersonalManagerSid))
            {
                string poralUrl = ConfigurationManager.AppSettings["PortalUrl"];
                string link = $"{poralUrl}/Recruit/VacancyCard?id={Id}";
                string text = $"Добрый день.<br />Вам назначена проработка новой вакансии.<br />Ссылка - <a href=\"{link}\">{link}</a>";
                MessageHelper.SendMailSmtp($"[Вакансия №{Id}]", text, true, Employee.GetEmailBySid(PersonalManagerSid));
            }
        }

        public static void SetState(int id, string stateSysName, string creatorSid, string descr)
        {
            SqlParameter pid = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pstateSysName = new SqlParameter() { ParameterName = "state_sys_name", SqlValue = stateSysName, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pdescr = new SqlParameter() { ParameterName = "descr", SqlValue = descr, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_set_state", pid, pstateSysName, pCreatorAdSid, pdescr);
        }

        public static IEnumerable<RecruitVacancy> GetList(out int totalCount, int? topRows = null, int? pageNum = null, int? idVacancy = null, string vacancyName = null, string deadlineDate = null, string personalManagerName = null, string dateCreate = null, string state = null, bool? activeOnly = null,string persManagerSid = null, string viewerSid = null)
        {
            if (!topRows.HasValue) topRows = 30;
            if (!pageNum.HasValue) pageNum = 1;

            SqlParameter ptopRows = new SqlParameter() { ParameterName = "top_rows", SqlValue = topRows, SqlDbType = SqlDbType.Int };
            SqlParameter ppageNum = new SqlParameter() { ParameterName = "page_num", SqlValue = pageNum, SqlDbType = SqlDbType.Int };
            SqlParameter pidVacancy = new SqlParameter() { ParameterName = "id", SqlValue = idVacancy, SqlDbType = SqlDbType.Int };
            SqlParameter pvacancyName = new SqlParameter() { ParameterName = "vacancy_name", SqlValue = vacancyName, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pdeadlineDate = new SqlParameter() { ParameterName = "deadline_date", SqlValue = deadlineDate, SqlDbType = SqlDbType.NVarChar };
            SqlParameter ppersonalManagerName = new SqlParameter() { ParameterName = "personal_manager_name", SqlValue = personalManagerName, SqlDbType = SqlDbType.NVarChar };
            SqlParameter ppersonalManagerSid = new SqlParameter() { ParameterName = "personal_manager_sid", SqlValue = persManagerSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pdateCreate = new SqlParameter() { ParameterName = "date_create", SqlValue = dateCreate, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pstate = new SqlParameter() { ParameterName = "state", SqlValue = state, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pactiveOnly = new SqlParameter() { ParameterName = "active_only", SqlValue = activeOnly, SqlDbType = SqlDbType.Bit };
            SqlParameter pViewerSid = new SqlParameter() { ParameterName = "viewer_sid", SqlValue = viewerSid, SqlDbType = SqlDbType.VarChar };//Пользователь который зашел на страничку
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_get_list", ptopRows, ppageNum, pidVacancy, pvacancyName, pdeadlineDate, ppersonalManagerName, pdateCreate, pstate, pactiveOnly, ppersonalManagerSid, pViewerSid);

            totalCount = 0;
            var lst = new List<RecruitVacancy>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var model = new RecruitVacancy(row);
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
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_close", pId, pDeleterSid);
        }

        public static void Change(string creatorSid, int id, string personalManagerSid)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter ppersonalManagerSid = new SqlParameter() { ParameterName = "personal_manager_sid", SqlValue = personalManagerSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_change", pId, pCreatorAdSid, ppersonalManagerSid);
        }

        public static IEnumerable<HistoryItem> GetHistory(out int totalCount, int id, bool fullList = false)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pFullList= new SqlParameter() { ParameterName = "full_list", SqlValue = fullList, SqlDbType = SqlDbType.Bit };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_get_history", pId, pFullList);

            totalCount = 0;
            var lst = new List<HistoryItem>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var model = new HistoryItem(row);
                    lst.Add(model);
                }
                totalCount = Db.DbHelper.GetValueIntOrDefault(dt.Rows[0], "total_count");
            }
            return lst;
        }

        public static IEnumerable<RecruitSelection> GetCandidateList(out int totalCount, int id, string viewerSid = null)
        {
           return RecruitSelection.GetList(out totalCount, id, viewerSid: viewerSid);
        }

        public static void AppendCandidateList(int id, int[] idCandidates, string creatorSid, int? idCameType)
        {
            foreach (int idCandidate in idCandidates)
            {
                var sel = new RecruitSelection() {IdVacancy = id, IdCandidate = idCandidate, IdCameType = idCameType };
                sel.Create(creatorSid);
            }
        }

        public static IEnumerable<StateItem> GetStateList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_get_state_list");
            var lst = new List<StateItem>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var model = new StateItem(row);
                    lst.Add(model);
                }
            }
            return lst;
        }
    }
}