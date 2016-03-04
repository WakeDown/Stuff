namespace DALStuff.Models
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Enabled = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeSid { get; set; }
        public bool Enabled { get; set; }
        public virtual employee Employee { get; set; }
    }
}
