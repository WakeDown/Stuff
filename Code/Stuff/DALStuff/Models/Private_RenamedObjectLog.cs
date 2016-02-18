using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class Private_RenamedObjectLog
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string OriginalName { get; set; }
    }
}
