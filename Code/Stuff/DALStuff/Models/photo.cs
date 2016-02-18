namespace DALStuff.Models
{
    public partial class photo
    {
        public int id { get; set; }
        public int id_employee { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public string path { get; set; }
        public byte[] picture { get; set; }
        public string picture_name { get; set; }
        public string creator_sid { get; set; }
    }
}
