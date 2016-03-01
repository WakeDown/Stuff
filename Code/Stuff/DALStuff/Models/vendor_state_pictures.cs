namespace DALStuff.Models
{
    public partial class vendor_state_pictures
    {
        public int id { get; set; }
        public int id_vendor_state { get; set; }
        public byte[] file_data { get; set; }
        public bool enabled { get; set; }
        public System.Guid file_fuid { get; set; }
        public string file_name { get; set; }
    }
}
