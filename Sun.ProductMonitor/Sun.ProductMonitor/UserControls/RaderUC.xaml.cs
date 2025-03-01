﻿using Sun.ProductMonitor.Models;
using System;
using System.Collections.Generic;
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
    /// RaderUC.xaml の相互作用ロジック
    /// </summary>
    public partial class RaderUC : UserControl
    {
        public RaderUC()
        {
            InitializeComponent();

            //界面发生变化时重新画图
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }

        /// <summary>
        /// 数据源，支持数据绑定,依赖属性
        /// </summary>


        public List<RaderModel> ItemSource
        {
            get { return (List<RaderModel>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(List<RaderModel>), typeof(RaderUC));

        /// <summary>
        /// 画图方法
        /// </summary>
        public void Drag()
        {
            //判断是否有数据
            if (ItemSource == null || ItemSource.Count == 0)
            {
                return;
            }
            //清空原先图案
            MainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();

            //调整大小（正方形）
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Height = size;
            LayGrid.Width = size;
            //半径
            double radius = size / 2;
            //每一步（数据数量）占雷达的角度
            double step = 360.0 / ItemSource.Count;

            for (int i = 0; i < ItemSource.Count; i++)
            {
                //X Y坐标
                double x = (radius - 20) * Math.Cos((step * i - 90) * Math.PI / 180);
                double y = (radius - 20) * Math.Sin((step * i - 90) * Math.PI / 180);

                P1.Points.Add(new Point(radius + x,radius + y));

                P2.Points.Add(new Point(radius + x*0.75, radius + y*0.75));

                P3.Points.Add(new Point(radius + x*0.5, radius + y*0.5));

                P4.Points.Add(new Point(radius + x*0.25, radius + y*0.25));

                //数据形状
                P5.Points.Add(new Point(radius + x * ItemSource[i].Value*0.01,radius + y*ItemSource[i].Value*0.01));

                //数据名称
                TextBlock txt = new TextBlock();
                txt.Width = 60;
                txt.FontSize = 10;
                txt.HorizontalAlignment = HorizontalAlignment.Center;
                txt.Text = ItemSource[i].ItemName;
                txt.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                //数据名文字位置
                //左边距
                txt.SetValue(Canvas.LeftProperty,radius+(radius-10)*Math.Cos((step*i-90)*Math.PI/180)-20);
                //上边距
                txt.SetValue(Canvas.TopProperty, radius + (radius - 10) * Math.Sin((step * i - 90) * Math.PI / 180) - 7);

                MainCanvas.Children.Add(txt);
            }
        }
    }
}
