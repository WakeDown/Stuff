namespace DALStuff.Models
{
    public partial class recruit_vacancy_states
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sys_name { get; set; }
        public int order_num { get; set; }
        public bool enabled { get; set; }
        public bool is_active { get; set; }
        public bool is_end { get; set; }
        public string background_color { get; set; }
    }
}
