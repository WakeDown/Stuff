namespace DALStuff.Models
{
    public partial class recruit_selection_states
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sys_name { get; set; }
        public int order_num { get; set; }
        public bool enabled { get; set; }
        public bool show_next_state_btn { get; set; }
        public bool is_active { get; set; }
        public string btn_name { get; set; }
        public bool is_accept { get; set; }
        public bool is_cancel { get; set; }
    }
}
