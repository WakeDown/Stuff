using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Models
{
    public enum CoordinationDocumentTypes
    {
        Request = 1,
        Other = 2,
    }

    public class JsonDocumentLinkType
    {
        public CoordinationDocumentTypes Type { get; set; }
        public string ConnString { get; set; }
        public int DocId { get; set; }
    }
}