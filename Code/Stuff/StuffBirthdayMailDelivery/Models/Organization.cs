using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Stuff.Objects;

namespace StuffDelivery.Models
{
    public class Organization:DbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Organization()
        {
            
        }

        public Organization(int id) : this()
        {
            Uri uri = new Uri(String.Format("{0}/Organization/Get?id={1}", OdataServiceUri, id));
            string jsonString = GetJson(uri);
            var model = JsonConvert.DeserializeObject<Organization>(jsonString);
            FillSelf(model);
        }

        private void FillSelf(Organization model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
}