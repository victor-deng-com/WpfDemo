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

namespace Demo04_RadioButtonAndDatePicker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_showTime_Click(object sender, RoutedEventArgs e)
        {
            //未选择时间时，DatePicker.SelectedDate为空
            //选择时间时，DatePicker.SelectedDate为选择的日期，不包含时分秒
            DateTime? selected = dp_selected.SelectedDate;
            if (selected == null)
            {
                MessageBox.Show("未选择时间");
            }
            else
            {
                MessageBox.Show(selected.ToString());
            }

        }
    }
}
