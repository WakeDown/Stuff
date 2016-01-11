using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Helpers;
using Newtonsoft.Json;
using Stuff.Models;
using Stuff.Objects;
using StuffDelivery.Helpers;
using StuffDelivery.Objects;

namespace StuffDelivery.Models
{
    internal class EngeneerState
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string EngeneerSid { get; set; }
        public string EngeneerName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string StateDescription { get; set; }
        public byte[] Picture { get; set; }
        public DateTime EndDate { get; set; }
        public int UnitOrganizationId { get; set; }
        public string UnitOrganizationName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }

        public EngeneerState() { }

        public EngeneerState(int id)
        {
            SqlParameter pId = new SqlParameter()
            {
                ParameterName = "id",
                SqlValue = id,
                SqlDbType = SqlDbType.Int
            };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("engeneer_state_get", pId);
            FillSelf(dt.Rows[0]);
        }
        public EngeneerState(DataRow row)
        {
            FillSelf(row);
        }

        private void FillSelf(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            StateName = Db.DbHelper.GetValueString(row, "name");
            EngeneerSid = Db.DbHelper.GetValueString(row, "engeneer_sid");
            EngeneerName = Db.DbHelper.GetValueString(row, "engeneer_name");
            VendorId = Db.DbHelper.GetValueIntOrDefault(row, "id_vendor");
            VendorName = Db.DbHelper.GetValueString(row, "vendor_name");
            StateDescription = Db.DbHelper.GetValueString(row, "descr");
            Picture = Db.DbHelper.GetByteArr(row, "pic_data");
            EndDate = Db.DbHelper.GetValueDateTimeOrDefault(row, "date_end");
            UnitOrganizationId = Db.DbHelper.GetValueIntOrDefault(row, "id_organization");
            UnitOrganizationName = Db.DbHelper.GetValueString(row, "organization_name");
            //     UnitOrganizationId = Db.DbHelper.GetValueIntOrDefault(row, )
            LanguageId = Db.DbHelper.GetValueIntOrDefault(row, "id_language");
            LanguageName = Db.DbHelper.GetValueString(row, "language");
            Author = Db.DbHelper.GetValueString(row, "creator");
            CreationDate = Db.DbHelper.GetValueDateTimeOrDefault(row, "date_create");
        }

        public static IEnumerable<EngeneerState> GetList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("engeneer_state_get_list");
            var list = new List<EngeneerState>();
            foreach (DataRow row in dt.Rows)
            {
                var vnd = new EngeneerState(row);
                list.Add(vnd);
            }
            return (list);
        }
        public static IEnumerable<EngeneerState> GetHistoryList(int id)
        {
            SqlParameter pId = new SqlParameter()
            {
                ParameterName = "id",
                SqlValue = id,
                SqlDbType = SqlDbType.Int
            };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("engeneer_state_get_history", pId);
            var list = new List<EngeneerState>();
            foreach (DataRow row in dt.Rows)
            {
                var vnd = new EngeneerState(row);
                list.Add(vnd);
            }
            return (list);
        }
        public static void SetDeliverySent(int id, byte expires, byte newbie, byte updated)
        {
            SqlParameter pExp = new SqlParameter()
            {
                ParameterName = "expired",
                SqlValue = expires,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter pNew = new SqlParameter()
            {
                ParameterName = "new",
                SqlValue = newbie,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter pUpd = new SqlParameter()
            {
                ParameterName = "updated",
                SqlValue = updated,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter pId = new SqlParameter()
            {
                ParameterName = "id",
                SqlValue = id,
                SqlDbType = SqlDbType.Int
            };
            Db.Stuff.ExecuteStoredProcedure("engeneer_state_set_delivery_sent", pId, pExp, pNew, pUpd);
        }
        public static List<KeyValuePair<EngeneerState, EngeneerState>> GetCurPrevPairs(IEnumerable<EngeneerState> curList)
        {
            if (curList.Any())
            {
                var list = new List<KeyValuePair<EngeneerState, EngeneerState>>();
                foreach (var cur in curList)
                {
                    var id = cur.Id;
                    var prev = GetPrevValue(id);
                    list.Add(new KeyValuePair<EngeneerState, EngeneerState>(cur, prev));
                }
                return (list);
            }
            return null;

        }
        public static EngeneerState GetPrevValue(int id)
        {
            if (id != 0)
            {
                SqlParameter pId = new SqlParameter()
                {
                    ParameterName = "id",
                    SqlValue = id,
                    SqlDbType = SqlDbType.Int
                };
                var prev = new EngeneerState(Db.Stuff.ExecuteQueryStoredProcedure("engeneer_state_get_prev_version", pId).Rows[0]);
                return prev;
            }
            return null;
        }
        public static IEnumerable<EngeneerState> GetDeliverList(byte expires, byte newbie, byte updated)
        {
            SqlParameter pExp = new SqlParameter()
            {
                ParameterName = "expires",
                SqlValue = expires,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter pNew = new SqlParameter()
            {
                ParameterName = "newbie",
                SqlValue = newbie,
                SqlDbType = SqlDbType.Bit
            };
            SqlParameter pUpd = new SqlParameter()
            {
                ParameterName = "updated",
                SqlValue = updated,
                SqlDbType = SqlDbType.Bit
            };
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("engener_state_get_expires_list", pExp, pNew, pUpd);
            var list = new List<EngeneerState>();
            foreach (DataRow row in dt.Rows)
            {
                var vnd = new EngeneerState(row);
                list.Add(vnd);
            }
            return (list);
        }
        internal void Save(string creatorSid)
        {
            bool isNew = Id == 0;

            SqlParameter pId = new SqlParameter()
            {
                ParameterName = "id",
                SqlValue = Id,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter pName = new SqlParameter()
            {
                ParameterName = "name",
                SqlValue = StateName,
                SqlDbType = SqlDbType.NChar
            };
            SqlParameter pEngeneerSid = new SqlParameter()
            {
                ParameterName = "engeneer_sid",
                SqlValue = EngeneerSid,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter pIdVendor = new SqlParameter()
            {
                ParameterName = "id_vendor",
                SqlValue = VendorId,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter pDescription = new SqlParameter()
            {
                ParameterName = "descr",
                SqlValue = StateDescription,
                SqlDbType = SqlDbType.NVarChar
            };
            SqlParameter pDateEnd = new SqlParameter()
            {
                ParameterName = "date_end",
                SqlValue = EndDate,
                SqlDbType = SqlDbType.DateTime
            };
            SqlParameter pIdOrganization = new SqlParameter()
            {
                ParameterName = "id_organization",
                SqlValue = UnitOrganizationId,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter pIdLanguage = new SqlParameter()
            {
                ParameterName = "id_language",
                SqlValue = LanguageId,
                SqlDbType = SqlDbType.Int
            };
            SqlParameter pCreatorSid = new SqlParameter()
            {
                ParameterName = "creator_sid",
                SqlValue = creatorSid,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter pPicData = new SqlParameter()
            {
                ParameterName = "pic_data",
                SqlValue = Picture,
                SqlDbType = SqlDbType.VarBinary
            };

            var dt = Db.Stuff.ExecuteQueryStoredProcedure("engeneer_state_save", pId, pName, pIdVendor, pDescription,
                pDateEnd, pIdOrganization, pIdLanguage, pCreatorSid, pPicData, pEngeneerSid);
            var body = new StringBuilder("Добрый день.<br/>");
            UnitOrganizationName = new Organization(UnitOrganizationId).Name;
            VendorName = new Vendor(VendorId).Name;
            var mailTo = Employee.GetFullRecipientList(null);
            var stuffUrl = ConfigurationManager.AppSettings["StuffUrl"];

            if (dt.Rows.Count > 0)
            {
                int id;
                int.TryParse(dt.Rows[0]["id"].ToString(), out id);
                Id = id;
            }

        }

        public static IEnumerable<string> GetMailAddressEngeneerStateExpiresDeliveryList()
        {
            var sidList = AdHelper.GetUserListByAdGroup(AdGroup.EngeneerStateExpiresDelivery);
            var mailList = new List<string>();
            foreach (var sid in sidList)
            {
                var mail = Employee.GetEmailBySid(sid.Key);
                mailList.Add(mail);
            }
            return (mailList);
        }

        public static void Close(int id, string deleter)
        {
            SqlParameter pDeleter = new SqlParameter()
            {
                ParameterName = "deleter_sid",
                SqlValue = deleter,
                SqlDbType = SqlDbType.VarChar
            };
            SqlParameter pId = new SqlParameter()
            {
                ParameterName = "id",
                SqlValue = id,
                SqlDbType = SqlDbType.Int
            };
            Db.Stuff.ExecuteStoredProcedure("engeneer_state_close", pId, pDeleter);
        }
    }
}
