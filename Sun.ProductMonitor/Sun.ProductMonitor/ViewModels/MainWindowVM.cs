using Sun.ProductMonitor.Models;
using Glimpse.AspNet.Model;
using Sun.ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sun.ProductMonitor.ViewModels
{
    internal class MainWindowVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		
        /// <summary>
        /// 初始化环境监控数据
        /// </summary>
        public MainWindowVM() {
            EnviromentList = new List<EnviromentModel>();
            EnviromentList.Add(new EnviromentModel { EnItemName = "光照（Lux）", EnItemValue = 123 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "噪音（db）", EnItemValue = 55 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "温度（℃）", EnItemValue = 80 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "湿度（%）", EnItemValue = 43 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "PM2.5（m³）", EnItemValue = 20 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "硫化氢（PPM）", EnItemValue = 15 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "氮气（PPM）", EnItemValue = 18 });
            
            AlarmList = new List<AlarmModel>();
            AlarmList.Add(new AlarmModel { Num = "01", Msg = "设备温度过高", Time = "2024-12-31 20:17:24",Duration=5 });
            AlarmList.Add(new AlarmModel { Num = "02", Msg = "工厂湿度过高", Time = "2025-01-23 18:24:19", Duration = 7 });
            AlarmList.Add(new AlarmModel { Num = "03", Msg = "工厂光照不足", Time = "2025-01-10 08:04:16 ", Duration = 4 });
            AlarmList.Add(new AlarmModel { Num = "04", Msg = "设备气压不足", Time = "2025-02-01 21:03:16", Duration = 1 });

            DeviceList = new List<DeviceModel>();
            DeviceList.Add(new DeviceModel { DeviceItem = "电能（Kw.h）", Value = 15.6});
            DeviceList.Add(new DeviceModel { DeviceItem = "电压(V)", Value = 21.4});
            DeviceList.Add(new DeviceModel { DeviceItem = "电流(A)", Value = 18.4});
            DeviceList.Add(new DeviceModel { DeviceItem = "压差（Kpa）", Value = 12.1});
            DeviceList.Add(new DeviceModel { DeviceItem = "温度（℃）", Value = 15.7});
            DeviceList.Add(new DeviceModel { DeviceItem = "震动（mm/s）", Value = 29.1});
            DeviceList.Add(new DeviceModel { DeviceItem = "气压(Kpa)", Value = 32.1});

            RaderList = new List<RaderModel>();
            RaderList.Add(new RaderModel { ItemName = "排烟风机", Value = 90 });
            RaderList.Add(new RaderModel { ItemName = "客梯", Value = 30.00 });
            RaderList.Add(new RaderModel { ItemName = "供水机", Value = 34.89 });
            RaderList.Add(new RaderModel { ItemName = "喷淋水泵", Value = 69.59 });
            RaderList.Add(new RaderModel { ItemName = "稳压设备", Value = 20 });

            StuffOutWorkList = new List<StuffOutWorkModel>();
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "张三", Position = "操作员", OutWorkCount = "2"});
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "李四", Position = "技术员", OutWorkCount = "5" });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "王五", Position = "统计员", OutWorkCount = "12" });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "马克思", Position = "操作员", OutWorkCount = "19" });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "迈克尔", Position = "调查员", OutWorkCount = "70" });

            WorkShopList = new List<WorkShopModel>();
            WorkShopList.Add(new WorkShopModel { WorkShopName = "贴片车间", WorkingCount = 31, WaitCount = 1, WrongCount = 2, StopCount = 1});
            WorkShopList.Add(new WorkShopModel { WorkShopName = "封装车间", WorkingCount = 32, WaitCount = 2, WrongCount = 1, StopCount = 0 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "焊接车间", WorkingCount = 40, WaitCount = 4, WrongCount = 3, StopCount = 2 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "贴片车间", WorkingCount = 34, WaitCount = 1, WrongCount = 2, StopCount = 1 });

            MachineList = new List<MachineModel>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000);
                int complate = random.Next(100, plan);
                MachineList.Add(new MachineModel
                {
                    MachineName = "焊接机-" + (i+1),
                    FinishedCount = complate,
                    PlanCount = plan,
                    Status = "作业中",
                    OrderNo = "H20251129520"
                });
            }
        
        }

        /// <summary>
        /// 监控用户控件
        /// </summary>
        private UserControl _MonitorUC;

		public UserControl MonitorUC
        {
			get {
				if (_MonitorUC == null)
				{
					_MonitorUC = new MonitorUC();
				}
				return _MonitorUC; 
			}
			set { 
				_MonitorUC = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
				}
			}
		}
        #region 时间 日期
        /// <summary>
        /// 时间 小时：分钟
        /// </summary>
        public string TimeStr
		{
			get 
			{ 
				return DateTime.Now.ToString("HH:mm");
			}
		}

		/// <summary>
		/// 日期 年-月-日
		/// </summary>
        public string DateStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

		public string WeekStr
		{
			get 
			{
				int index =  (int)DateTime.Now.DayOfWeek;
				string[] week = new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
				return week[index];
			}
		}
        #endregion

        #region 机台、生产、不良计数显示
        /// <summary>
        /// 机台总数
        /// </summary>
        private string _MachineCount = "0298";

		public string MachineCount
		{
			get { return _MachineCount; }
			set { 
				_MachineCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
                }
            }
		}

		/// <summary>
		/// 生产计数
		/// </summary>
        private string _ProductCount = "1643";

        public string ProductCount
        {
            get { return _ProductCount; }
            set
            {
                _ProductCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductCount"));
                }
            }
        }

        /// <summary>
        /// 不良计数
        /// </summary>
        private string _BadCount = "924";

        public string BadCount
        {
            get { return _ProductCount; }
            set
            {
                _BadCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BadCount"));
                }
            }
        }
        #endregion

        #region 环境监控数据
        private List<EnviromentModel> _EnviromentList;

        public List<EnviromentModel> EnviromentList
        {
            get { return _EnviromentList; }
            set 
            {
                _EnviromentList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EnviromentList"));
                }
            }
        }
        #endregion

        #region 报警属性
        private List<AlarmModel> _AlarmList;

        public List<AlarmModel> AlarmList
        {
            get { return _AlarmList; }
            set 
            {
                _AlarmList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AlarmList"));
                }
            }
        }
        #endregion

        #region 设备报警信息
        private List<DeviceModel> _DeviceList;

        public List<DeviceModel> DeviceList
        {
            get { return _DeviceList; }
            set 
            {
                _DeviceList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DeviceList"));
                }
            }
        }

        #endregion

        #region 雷达数据
        private List<RaderModel> _RaderList;

        public List<RaderModel> RaderList
        {
            get { return _RaderList; }
            set { 
                _RaderList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RaderList"));
                }
            }
        }

        #endregion

        #region 人力数据
        private List<StuffOutWorkModel> _StuffOutWorkList;

        public List<StuffOutWorkModel> StuffOutWorkList
        {
            get { return _StuffOutWorkList; }
            set { 
                _StuffOutWorkList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RaderList"));
                }
            }
        }
        #endregion

        #region 车间属性

        private List<WorkShopModel> _WorkShopList;

        public List<WorkShopModel> WorkShopList
        {
            get { return _WorkShopList; }
            set { 
                _WorkShopList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkShopList"));
                }
            }
        }

        #endregion

        #region 机台集合属性
        private List<MachineModel> _MachineList;

        public List<MachineModel> MachineList
        {
            get { return _MachineList; }
            set { 
                _MachineList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkShopList"));
                }
            }
        }

        #endregion
    }
}
