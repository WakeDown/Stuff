﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Models
{
    public class EmployeeSm
    {
        public int Id { get; set; }
        public string AdSid { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }

        public EmployeeSm()
        {
        }
    }
}