using System;

namespace DALStuff.Models
{
    public partial class document_meet_links
    {
        public int id { get; set; }
        public int id_document { get; set; }
        public Nullable<int> id_department { get; set; }
        public Nullable<int> id_position { get; set; }
        public Nullable<int> id_employee { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string creator_sid { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim2 { get; set; }
        public string deleter_sid { get; set; }
    }
}
