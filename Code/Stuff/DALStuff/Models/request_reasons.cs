using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class request_reasons
    {
        public request_reasons()
        {
            this.requests = new List<request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public virtual ICollection<request> requests { get; set; }
    }
}
