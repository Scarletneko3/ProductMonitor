﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sun.ProductMonitor.UserControls
{
    /// <summary>
    /// RingUC.xaml の相互作用ロジック
    /// </summary>
    public partial class RingUC : UserControl
    {
        public RingUC()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DragRing();
        }

        /// <summary>
        /// 百分比值
        /// </summary>
        public double PercentValue
        {
            get { return (double)GetValue(PercentValueProperty); }
            set { SetValue(PercentValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PercentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentValueProperty =
            DependencyProperty.Register("PercentValue", typeof(double), typeof(RingUC));

        /// <summary>
        /// 画圆环方法
        /// </summary>
        private void DragRing()
        {
            LayOutGrid.Width = Math.Min(RenderSize.Width, RenderSize.Height);
            double radius = LayOutGrid.Width / 2;

            double x = radius + (radius - 3) * Math.Cos((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);
            double y = radius + (radius - 3) * Math.Sin((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);
        
            int Is50 = PercentValue < 50 ? 0 : 1;
            string pathStr = $"M{radius + 0.01} 3A{radius - 3} {radius - 3} 0 {Is50} 1 {x} {y}";//移动路径
            
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            path.Data=(Geometry)converter.ConvertFrom(pathStr);
        }
    }
}
