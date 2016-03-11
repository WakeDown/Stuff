using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class request_history
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int RequestOldStatusId { get; set; }
        public int RequestNewStatusId { get; set; }
        public string CrteatorSid { get; set; }
        public System.DateTime Date { get; set; }
        public virtual employee Creator { get; set; }
        public virtual request Request { get; set; }
        public virtual RequestStatus NewRequestStatuses { get; set; }
        public virtual RequestStatus OldRequestStatuses { get; set; }
    }
}
