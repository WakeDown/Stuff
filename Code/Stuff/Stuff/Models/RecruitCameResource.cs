using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitCameResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RecruitCameResource()
        {

        }

        public RecruitCameResource(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            Name = Db.DbHelper.GetValueString(row, "name");
        }

        public static IEnumerable<RecruitCameResource> GetList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_came_resource_get_list");
            var list = new List<RecruitCameResource>();
            foreach (DataRow row in dt.Rows)
            {
                var es = new RecruitCameResource(row);
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