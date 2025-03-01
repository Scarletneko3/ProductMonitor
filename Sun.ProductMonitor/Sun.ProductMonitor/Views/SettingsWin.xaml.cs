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
using System.Windows.Shapes;

namespace Sun.ProductMonitor.Views
{
    /// <summary>
    /// SettingsWin.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingsWin : Window
    {
        public SettingsWin()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("pack://application:,,,/Sun.ProductMonitor;component/Views/SettingsPage.xaml#" + (sender as RadioButton)?.Tag.ToString(), UriKind.Absolute));
        }
    }
}
