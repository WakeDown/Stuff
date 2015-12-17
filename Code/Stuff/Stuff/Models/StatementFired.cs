using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Models
{
    public class StatementFired : Statement
    {
        public DateTime DateFired { get; set; }
        public string SidEmployee { get; set; }

        public StatementFired()
        {
            DateFired = DateTime.Now.AddDays(1);
        }

        public StatementFired(string sidEmployee):this()
        {
            SidEmployee = sidEmployee;
        }

        public void Configure()
        {

            base.Configure(SidEmployee);
            SetMatchersOficial(SidEmployee);

            Name = "З А Я В Л Е Н И Е";
            Text =string.Format("Прошу уволить меня по собственному желанию  {0:dd.MM.yyyy} г.",DateFired);
        }
    }
}