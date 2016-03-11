using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            this.requests = new List<request>();
            this.request_history_to_new_status = new List<request_history>();
            this.request_history_to_old_status = new List<request_history>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public virtual ICollection<request> requests { get; set; }
        public virtual ICollection<request_history> request_history_to_new_status { get; set; }
        public virtual ICollection<request_history> request_history_to_old_status { get; set; }

    }
}
