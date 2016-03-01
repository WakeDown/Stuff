namespace DALStuff.Models
{
    public partial class city
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool enabled { get; set; }
        public System.DateTime dattim1 { get; set; }
        public System.DateTime dattim2 { get; set; }
        public int order_num { get; set; }
        public string creator_sid { get; set; }
        public string sys_name { get; set; }
    }
}
