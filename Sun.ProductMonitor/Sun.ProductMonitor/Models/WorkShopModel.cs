using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.ProductMonitor.Models
{
    /// <summary>
    /// 车间数据
    /// </summary>
    class WorkShopModel
    {
        /// <summary>
        /// 车间名称
        /// </summary>
        public string WorkShopName { get; set; }
        /// <summary>
        /// 作业数量
        /// </summary>
        
        public int WorkingCount { get; set; }
        /// <summary>
        /// 等待数量
        /// </summary>
        public int WaitCount { get; set; }
        /// <summary>
        /// 故障数量
        /// </summary>
        public int WrongCount { get; set; }
        /// <summary>
        /// 停机数量
        /// </summary>
        public int StopCount { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { 
            get 
            {
                return WorkingCount + WaitCount + StopCount + WrongCount;
            }
        }

    }
}
