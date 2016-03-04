namespace DALStuff.Models
{
    public partial class statement_types
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sys_name { get; set; }
        public int order_num { get; set; }
        public bool enabled { get; set; }
        public string group_sys_name { get; set; }
        public string descr { get; set; }
    }
}
