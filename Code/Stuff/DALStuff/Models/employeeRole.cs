namespace DALStuff.Models
{
    public partial class employeeRole
    {
        public int id { get; set; }
        public string name { get; set; }
        public int employeeId { get; set; }
        public bool enabled { get; set; }
        public virtual employee employee { get; set; }
    }
}
