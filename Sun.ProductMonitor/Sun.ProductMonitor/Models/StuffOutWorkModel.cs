using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.ProductMonitor.Models
{
    internal class StuffOutWorkModel
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StuffName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 缺岗次数
        /// </summary>
        public string OutWorkCount { get; set; }
    }
}
