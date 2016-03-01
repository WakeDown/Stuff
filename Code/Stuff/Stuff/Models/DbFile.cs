using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Models
{
    public class DbFile
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Sid { get; set; }
    }
}