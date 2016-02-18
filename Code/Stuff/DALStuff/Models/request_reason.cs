using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class RequestReason
    {
        public RequestReason()
        {
            this.Requests = new List<request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public virtual ICollection<request> Requests { get; set; }
    }
}
