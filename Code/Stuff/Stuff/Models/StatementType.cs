using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Objects;
using Newtonsoft.Json;

namespace Stuff.Models
{
    public class StatementType:DbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNum { get; set; }

        public StatementType() { }

        public static IEnumerable<StatementType> GetList()
        {
            Uri uri = new Uri(String.Format("{0}/Statement/GetTypeList", OdataServiceUri));
            string jsonString = GetJson(uri);
            var model = JsonConvert.DeserializeObject<IEnumerable<StatementType>>(jsonString);
            return model;
        }
    }
}