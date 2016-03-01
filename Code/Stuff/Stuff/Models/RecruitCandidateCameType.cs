using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitCandidateCameType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RecruitCandidateCameType()
        {

        }

        public RecruitCandidateCameType(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            Name = Db.DbHelper.GetValueString(row, "name");
        }

        public static IEnumerable<RecruitCandidateCameType> GetList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_candidate_get_came_type_list");
            var list = new List<RecruitCandidateCameType>();
            foreach (DataRow row in dt.Rows)
            {
                var es = new RecruitCandidateCameType(row);
                list.Add(es);
            }
            return (list);
        }

        public static SelectList GetSelectionList()
        {
            return new SelectList(GetList(), "Id", "Name");
        }
    }
}