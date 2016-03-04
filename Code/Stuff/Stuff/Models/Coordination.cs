using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Models
{
    public class Coordination
    {
        public int id { get; set; }
        /// <summary>
        /// связанный документ
        /// </summary>
        public string doc { get; set; }
        /// <summary>
        /// инициатор согласования
        /// </summary>
        public string sidСreator { get; set; }
        /// <summary>
        /// инициатор согласования
        /// </summary>
        public string creator { get; set; }
        /// <summary>
        /// Время завершения согласования
        /// </summary>
        public DateTimeOffset? endDate { get; set; }
        /// <summary>
        /// ступень согласования
        /// </summary>
        public int stat { get; set; }
        /// <summary>
        /// дата создания
        /// </summary>
        public DateTimeOffset? create_datetime { get; set; }
        /// <summary>
        /// дата последнего изменения
        /// </summary>
        public DateTimeOffset? last_change_datetime { get; set; }
        public bool enabled { get; set; }
    }
}