using System;
using System.Collections.Generic;

namespace DALStuff.Models
{
    public partial class departments_view
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_parent { get; set; }
        public string parent { get; set; }
        public int id_chief { get; set; }
        public string chief { get; set; }
        public int hidden { get; set; }
    }
}
