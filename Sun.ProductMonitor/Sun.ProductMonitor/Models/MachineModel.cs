using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.ProductMonitor.Models
{
    class MachineModel
    {
        public string MachineName { get; set; }
        public string Status { get; set; }
        public int PlanCount { get; set; }
        public int FinishedCount { get; set; }
        public string OrderNo { get; set; }
        public double Percent { 
            get
            {
                return FinishedCount *100.0 / (double)PlanCount;
            }
                }
    }
}
