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
        public int PeriodCount { get; set; }
        public bool HasBlockedPeriods { get; set; }

        EmployeeRestHoliday()
        {

        }

        public static List<EmployeeRestHoliday> GetEmployeeList(int year)
        {
            Uri uri = new Uri(string.Format("{0}/RestHoliday/GetEmployeeList?year={1}",OdataServiceUri,year));
            var jsonList = GetJson(uri);
            return JsonConvert.DeserializeObject<List<EmployeeRestHoliday>>(jsonList);
        }

        public static bool CanEdit (string employeeSid, int year, bool canEdit, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri(string.Format("{0}/RestHoliday/CanEdit?employeeSid={employeeSid}&year={1}&canEdit={2}", OdataServiceUri, year, canEdit));
            return PostJson(uri, String.Empty, out responseMessage);
        }
    }
}
