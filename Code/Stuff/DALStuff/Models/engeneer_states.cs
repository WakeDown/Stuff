using System;

namespace DALStuff.Models
{
    public partial class engeneer_states
    {
        public int id { get; set; }
        public string engeneer_sid { get; set; }
        public int id_vendor { get; set; }
        public string descr { get; set; }
        public System.DateTime date_end { get; set; }
        public int id_organization { get; set; }
        public int id_language { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public bool enabled { get; set; }
        public string creator_sid { get; set; }
        public string deleter_sid { get; set; }
        public Nullable<int> old_id { get; set; }
        public byte[] pic_data { get; set; }
        public System.Guid pic_guid { get; set; }
        public bool expired_delivery_sent { get; set; }
        public string name { get; set; }
        public bool new_delivery_sent { get; set; }
        public bool update_delivery_sent { get; set; }
    }
}
