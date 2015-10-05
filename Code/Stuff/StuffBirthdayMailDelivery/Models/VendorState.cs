using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Stuff.Objects;
using StuffDelivery.Models;

namespace Stuff.Models
{
    public class VendorState : DbModel
    {
        public int? Id { get; set; }
        public string StateName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string StateDescription { get; set; }
        public byte [] Picture { get; set; }
        public DateTime EndDate { get; set; }
        public int UnitOrganizationId { get; set; }
        public string UnitOrganizationName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }

        public VendorState(int id)
        {
            Uri uri = new Uri(String.Format("{0}/VendorState/Get?id={1}", OdataServiceUri, id));
             string jsonString = GetJson(uri);
            var vnd = JsonConvert.DeserializeObject<VendorState>(jsonString);
            FillSelf(vnd);
        }

        public VendorState()
        {
           
        }
        private void FillSelf(VendorState vnd)
        {
            Id = vnd.Id;
            StateName = vnd.StateName;
            VendorId = vnd.VendorId;
            VendorName = vnd.VendorName;
            StateDescription = vnd.StateDescription;
            Picture = vnd.Picture;
            EndDate = vnd.EndDate;
            UnitOrganizationId = vnd.UnitOrganizationId;
            LanguageId = vnd.LanguageId;
        }

        public static List<VendorState> GetList()
        {
            Uri uri = new Uri(String.Format("{0}/VendorState/GetList", OdataServiceUri));
            string json = GetJson(uri);
            var list = JsonConvert.DeserializeObject<List<VendorState>>(json);
            return (list);
        }

        public static List<VendorState> GetHistoryList(int id)
        {
            Uri uri = new Uri(String.Format("{0}/VendorState/GetHistoryList?id={1}", OdataServiceUri, id));
            string json = GetJson(uri);
            var list = JsonConvert.DeserializeObject<List<VendorState>>(json);
            return (list);
        }

        public static List<VendorState> GetDeliverList(byte type)
        {
            Uri uri = new Uri(String.Format("{0}/VendorState/GetDeliverList?listType={1}",OdataServiceUri,type));
            string json = GetJson(uri);
            var list = JsonConvert.DeserializeObject<List<VendorState>>(json);
            return (list);
        }

        public static List<KeyValuePair<VendorState, VendorState>> GetCurPrevPairs(List<VendorState> curList)
        {
            if (curList.Any())
            {
                var list = new List<KeyValuePair<VendorState, VendorState>>();
                foreach (var cur in curList)
                {
                    var id = cur.Id;
                    Uri uri = new Uri(String.Format("{0}/VendorState/GetPrevValue?id={1}", OdataServiceUri, id));
                    string json = GetJson(uri);
                    var prev = JsonConvert.DeserializeObject<VendorState>(json);
                    list.Add(new KeyValuePair<VendorState, VendorState>(cur, prev));
                }
                return (list);
            }
            return null;

        } 
        public static List<string> GetExpiredMailAddressList()
        {
            Uri uri = new Uri(String.Format("{0}/VendorState/GetExpiredMailAddressList", OdataServiceUri));
            string json = GetJson(uri);
            var list = JsonConvert.DeserializeObject<List<string>>(json);
            return (list);
        }
        public static bool SetDeliverySent(out ResponseMessage responseMessage, byte type, params VendorState[] vendorStates)
        {
            Uri uri = new Uri(String.Format("{0}/VendorState/SetDeliverySent?deliveryType={1}", OdataServiceUri,type));
            string json = JsonConvert.SerializeObject(vendorStates);
            bool result = PostJson(uri, json, out responseMessage);
            return result;
        }
    }
}
