using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitCandidate
    {
       public int Id { get; set; }
       public string Surname { get; set; }
       public string Name { get; set; }
       public string Patronymic { get; set; }
       public string DisplayName { get; set; }
       public bool Male { get; set; }
        public string MaleStr => Male ? "Муж." : "Жен.";
        public DateTime DateCreate { get; set; }
        public string CreatorSid { get; set; }
        public string CreatorName { get; set; }
        public int IdCameResource { get; set; }
        public string CameResourceName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateQueStr => BirthDate.HasValue ? BirthDate.Value.ToString("dd-MM-yyyy") : String.Empty;
        public string Phone { get; set; }
        public string Email { get; set; }

        public byte[] File { get; set; }
        public string FileName {get; set; }
        public string FileSid { get; set; }

        public int? Age
        {
            get
            {
                int? age = null;
                if (BirthDate.HasValue && BirthDate.Value.Year > 1900)
                {
                    age = (int)(DateTime.Now - BirthDate.Value).TotalDays/365;
                }
                return age;
            }
        }

        public string DateCreateStr => DateCreate.ToString("dd.MM.yyyy");

        public string LastSelectionStateName { get; set; }
        public string LastSelectionStateChangerName { get; set; }
        public DateTime? LastSelectionStateDateChange { get; set; }
        public string LastSelectionStateDateChangeStr => DateCreate.ToString("dd.MM.yyyy HH:mm");
        public int? IdCameType { get; set; }
        public string CameTypeName { get; set; }

        public RecruitCandidate()
        {

        }

        public RecruitCandidate(int id)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_get", pId);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                FillSelf(row);
            }
        }

        public RecruitCandidate(DataRow row)
            : this()
        {
            FillSelf(row);
        }

        private void FillSelf(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            CreatorSid = Db.DbHelper.GetValueString(row, "creator_sid");
            CreatorName = Db.DbHelper.GetValueString(row, "creator_name");
            Surname = Db.DbHelper.GetValueString(row, "surname");
            Name = Db.DbHelper.GetValueString(row, "name");
            Patronymic = Db.DbHelper.GetValueString(row, "patronymic");
            DisplayName = Db.DbHelper.GetValueString(row, "display_name");
            Male = Db.DbHelper.GetValueBool(row, "male");
            DateCreate = Db.DbHelper.GetValueDateTimeOrDefault(row, "dattim1");
            IdCameResource = Db.DbHelper.GetValueIntOrDefault(row, "id_came_resource");
            CameResourceName = Db.DbHelper.GetValueString(row, "came_resource_name");
            BirthDate = Db.DbHelper.GetValueDateTimeOrNull(row, "birth_date");
            Phone = Db.DbHelper.GetValueString(row, "phone");
            Email = Db.DbHelper.GetValueString(row, "email");
            FileSid = Db.DbHelper.GetValueString(row, "file_sid");
            FileName = Db.DbHelper.GetValueString(row, "file_name");
            LastSelectionStateName = Db.DbHelper.GetValueString(row, "selection_state_name");
            LastSelectionStateChangerName = Db.DbHelper.GetValueString(row, "selection_state_changer_name");
            LastSelectionStateDateChange = Db.DbHelper.GetValueDateTimeOrNull(row, "selection_state_change_date");
            IdCameType = Db.DbHelper.GetValueIntOrNull(row, "id_came_type");
            CameTypeName = Db.DbHelper.GetValueString(row, "came_type_name");
        }

        public void Create(string creatorSid)
        {
            DisplayName = Employee.ShortName($"{Surname} {Name} {Patronymic}").Trim();

            SqlParameter pSurname = new SqlParameter() { ParameterName = "surname", SqlValue = Surname, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pName = new SqlParameter() { ParameterName = "name", SqlValue = Name, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pPatronymic = new SqlParameter() { ParameterName = "patronymic", SqlValue = Patronymic, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pDisplayName = new SqlParameter() { ParameterName = "display_name", SqlValue = DisplayName, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pMale = new SqlParameter() { ParameterName = "male", SqlValue = Male, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pIdCameResource = new SqlParameter() { ParameterName = "id_came_resource", SqlValue = IdCameResource, SqlDbType = SqlDbType.Int };
            SqlParameter pBirthDate = new SqlParameter() { ParameterName = "birth_date", SqlValue = BirthDate, SqlDbType = SqlDbType.DateTime };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pPhone = new SqlParameter() { ParameterName = "phone", SqlValue = Phone, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pEmail = new SqlParameter() { ParameterName = "email", SqlValue = Email, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pFile = new SqlParameter() { ParameterName = "file", SqlValue = File, SqlDbType = SqlDbType.VarBinary };
            SqlParameter pFileName = new SqlParameter() { ParameterName = "file_name", SqlValue = FileName, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pIdCameType = new SqlParameter() { ParameterName = "id_came_type", SqlValue = IdCameType, SqlDbType = SqlDbType.Int };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_create", pSurname, pName, pPatronymic, pDisplayName, pMale, pIdCameResource, pBirthDate, pCreatorAdSid, pPhone, pEmail, pFile, pFileName, pIdCameType);
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                int.TryParse(dt.Rows[0]["id"].ToString(), out id);
                Id = id;
            }
        }

        public static IEnumerable<RecruitCandidate> GetList(out int totalCount, int? topRows = null, int? pageNum = null, string idStr = null, string fio = null, string age = null, string phone = null, string email = null, string added = null, bool? sex=null, string changed = null)
        {
            if (!topRows.HasValue) topRows = 30;
            if (!pageNum.HasValue) pageNum = 1;

            int id;
            int.TryParse(idStr, out id);

            SqlParameter ptopRows = new SqlParameter() { ParameterName = "top_rows", SqlValue = topRows, SqlDbType = SqlDbType.Int };
            SqlParameter ppageNum = new SqlParameter() { ParameterName = "page_num", SqlValue = pageNum, SqlDbType = SqlDbType.Int };
            SqlParameter pid = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pfio = new SqlParameter() { ParameterName = "fio", SqlValue = fio, SqlDbType = SqlDbType.NVarChar };
            SqlParameter page = new SqlParameter() { ParameterName = "age", SqlValue = age, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pPhone = new SqlParameter() { ParameterName = "phone", SqlValue = phone, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pEmail = new SqlParameter() { ParameterName = "email", SqlValue = email, SqlDbType = SqlDbType.NVarChar };
            SqlParameter padded = new SqlParameter() { ParameterName = "added", SqlValue = added, SqlDbType = SqlDbType.NVarChar };
            SqlParameter psex = new SqlParameter() { ParameterName = "sex", SqlValue = sex, SqlDbType = SqlDbType.Bit };
            SqlParameter pchanged = new SqlParameter() { ParameterName = "changed", SqlValue = changed, SqlDbType = SqlDbType.NVarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_get_list", ptopRows, ppageNum, pid, pfio, page, pPhone, pEmail, padded, psex, pchanged);

            totalCount = 0;
            var lst = new List<RecruitCandidate>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var model = new RecruitCandidate(row);
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
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_close", pId, pDeleterSid);
        }

        public static byte[] GetFileData(string sid, out string fileName)
        {
            SqlParameter pSid = new SqlParameter() { ParameterName = "sid", SqlValue = sid, SqlDbType = SqlDbType.NVarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_get_file", pSid);
            byte[] data = new byte[0];
            fileName = String.Empty;
            if (dt.Rows.Count > 0)
            {
                data = Db.DbHelper.GetByteArr(dt.Rows[0], "data");
                fileName = Db.DbHelper.GetValueString(dt.Rows[0], "file_name");
            }
            return data;
        }

        public void Change(string creatorSid)
        {
            DisplayName = Employee.ShortName($"{Surname} {Name} {Patronymic}").Trim();

            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = Id, SqlDbType = SqlDbType.Int };
            SqlParameter pSurname = new SqlParameter() { ParameterName = "surname", SqlValue = Surname, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pName = new SqlParameter() { ParameterName = "name", SqlValue = Name, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pPatronymic = new SqlParameter() { ParameterName = "patronymic", SqlValue = Patronymic, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pDisplayName = new SqlParameter() { ParameterName = "display_name", SqlValue = DisplayName, SqlDbType = SqlDbType.NVarChar };
            //SqlParameter pMale = new SqlParameter() { ParameterName = "male", SqlValue = Male, SqlDbType = SqlDbType.NVarChar };
            //SqlParameter pIdCameResource = new SqlParameter() { ParameterName = "id_came_resource", SqlValue = IdCameResource, SqlDbType = SqlDbType.Int };
            SqlParameter pBirthDate = new SqlParameter() { ParameterName = "birth_date", SqlValue = BirthDate, SqlDbType = SqlDbType.DateTime };
            SqlParameter pCreatorAdSid = new SqlParameter() { ParameterName = "creator_sid", SqlValue = creatorSid, SqlDbType = SqlDbType.VarChar };
            SqlParameter pPhone = new SqlParameter() { ParameterName = "phone", SqlValue = Phone, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pEmail = new SqlParameter() { ParameterName = "email", SqlValue = Email, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pFile = new SqlParameter() { ParameterName = "file", SqlValue = File, SqlDbType = SqlDbType.VarBinary };
            SqlParameter pFileName = new SqlParameter() { ParameterName = "file_name", SqlValue = FileName, SqlDbType = SqlDbType.NVarChar };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_change", pId, pSurname, pName, pPatronymic, pDisplayName,  pBirthDate, pCreatorAdSid, pPhone, pEmail, pFile, pFileName);
        }

        public static IEnumerable<HistoryItem> GetHistory(out int totalCount, int id, bool fullList = false)
        {
            SqlParameter pId = new SqlParameter() { ParameterName = "id", SqlValue = id, SqlDbType = SqlDbType.Int };
            SqlParameter pFullList = new SqlParameter() { ParameterName = "full_list", SqlValue = fullList, SqlDbType = SqlDbType.Bit };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_get_history", pId, pFullList);

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

        public static IEnumerable<RecruitSelection> GetVacancyList(out int totalCount, int id)
        {
            return RecruitSelection.GetList(out totalCount, idCandidate:id);
        }

        public static int CheckClone(string surname, string name, string patronymic)
        {
            SqlParameter psurname = new SqlParameter() { ParameterName = "surname", SqlValue = surname, SqlDbType = SqlDbType.NVarChar };
            SqlParameter pname = new SqlParameter() { ParameterName = "name", SqlValue = name, SqlDbType = SqlDbType.NVarChar };
            SqlParameter ppatronymic = new SqlParameter() { ParameterName = "patronymic", SqlValue = patronymic, SqlDbType = SqlDbType.NVarChar };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_check_clone", psurname, pname, ppatronymic);

            int id = 0;

            if (dt.Rows.Count > 0)
            {
                id = Db.DbHelper.GetValueIntOrDefault(dt.Rows[0], "id");
            }
            return id;
        }

        
    }
}