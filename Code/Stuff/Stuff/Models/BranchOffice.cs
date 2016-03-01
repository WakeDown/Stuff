using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProvider.Helpers;
using Newtonsoft.Json;
using Stuff.Objects;

namespace Stuff.Models
{
    public class BranchOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BranchOffice() { }

        public BranchOffice(DataRow row)
        {
            Id = Db.DbHelper.GetValueIntOrDefault(row, "id");
            Name = Db.DbHelper.GetValueString(row, "name");
        }

        public static SelectList GetSelectionList()
        {
            return new SelectList(GetList(), "Id", "Name");
        }

        public static IEnumerable<BranchOffice> GetList()
        {
            var dt = Db.Stuff.ExecuteQueryStoredProcedure("branch_office_get_list");
            var list = new List<BranchOffice>();
            foreach (DataRow row in dt.Rows)
            {
                var es = new BranchOffice(row);
                list.Add(es);
            }
            return (list);
        }
    }
}