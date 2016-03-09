using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProvider.Helpers;

namespace Stuff.Models
{
    public class RecruitVacancyType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RecruitVacancyType()
        {

        }

        public RecruitVacancyType(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            Name = Db.DbHelper.GetValueString(row, "name");
        }

        public static IEnumerable<RecruitVacancyType> GetList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("recruit_vacancy_type_get_list");
            var list = new List<RecruitVacancyType>();
            foreach (DataRow row in dt.Rows)
            {
                var es = new RecruitVacancyType(row);
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