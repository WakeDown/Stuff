namespace DALStuff.Models
{
    public partial class org_state_images
    {
        public int id { get; set; }
        public int id_organization { get; set; }
        public byte[] data { get; set; }
        public bool enabled { get; set; }
        public System.Guid data_sid { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
    }
}
