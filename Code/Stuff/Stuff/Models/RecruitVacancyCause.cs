using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitVacancyCause
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RecruitVacancyCause()
        {

        }

        public RecruitVacancyCause(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            Name = Db.DbHelper.GetValueString(row, "name");
        }

        public static IEnumerable<RecruitVacancyCause> GetList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_cause_get_list");
            var list = new List<RecruitVacancyCause>();
            foreach (DataRow row in dt.Rows)
            {
                var es = new RecruitVacancyCause(row);
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