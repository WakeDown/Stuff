using System;

namespace DALStuff.Models
{
    public partial class recruit_candidate_resume_files
    {
        public int id { get; set; }
        public int id_candidate { get; set; }
        public System.Guid sid { get; set; }
        public byte[] data { get; set; }
        public System.DateTime dattim1 { get; set; }
        public string creator_sid { get; set; }
        public string file_name { get; set; }
        public Nullable<bool> enabled { get; set; }
        public Nullable<System.DateTime> dattim2 { get; set; }
        public string deleter_sid { get; set; }
    }
}
