using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Objects;
using Newtonsoft.Json;

namespace Stuff.Models
{
    public class StatementPrint:DbModel
    {
        public int Id { get; set; }
        public int IdStatementType { get; set; }
        public string EmployeeSid { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? DurationHours { get; set; }
        public int? DurationDays { get; set; }
        public string Cause { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdOrganization { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? DateConfirm { get; set; }
        public EmployeeSm Employee { get; set; }

        public StatementPrint() { }

        public static IEnumerable<StatementPrint> GetList()
        {
            Uri uri = new Uri(String.Format("{0}/Statement/GetPrintList", OdataServiceUri));
            string jsonString = GetJson(uri);
            var model = JsonConvert.DeserializeObject<IEnumerable<StatementPrint>>(jsonString);
            return model;
        }

        public bool Save(out ResponseMessage responseMessage)
        {
            Uri uri = new Uri(String.Format("{0}/Statement/Save", OdataServiceUri));
            string json = JsonConvert.SerializeObject(this);
            bool result = PostJson(uri, json, out responseMessage);
            return result;
        }


    }
}