using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stuff.Objects;
using Newtonsoft.Json;

namespace Stuff.Models
{
    public class EmployeeRestHoliday:DbModel
    {
        public string EmployeeName { get; set; }
        public string EmployeeSid { get; set; }
        public int DurationSum { get; set; }
        public int Residue { get; set; }

        EmployeeRestHoliday()
        {

        }

        public static List<EmployeeRestHoliday> GetEmployeeList(int year)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/GetEmployeeList?year={year}");
            var jsonList = GetJson(uri);
            return JsonConvert.DeserializeObject<List<EmployeeRestHoliday>>(jsonList);
        }

        public static bool CanEdit (string employeeSid, int year, bool canEdit, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/CanEdit?employeeSid={employeeSid}&year={year}&canEdit={canEdit}");
            return PostJson(uri, String.Empty, out responseMessage);
        }
    }
}
