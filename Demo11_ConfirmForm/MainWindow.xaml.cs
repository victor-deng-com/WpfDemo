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

namespace Demo11_ConfirmForm
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

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            ConfirmForm cf = new ConfirmForm();
            bool? status=cf.ShowDialog();
            if (status == true)
            {
                MessageBox.Show("你点了确定");
            }
            else if (status == false)
            {
                //点了关闭时DialogResult也是false
                MessageBox.Show("你点了取消");
            }
            else
            {
                MessageBox.Show("你点了不确定");
            }
        }

        private void btn_messagebox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr= MessageBox.Show("这是提示的内容","这是提示的标题",MessageBoxButton.YesNoCancel);
            if (mbr==MessageBoxResult.Yes)
            {
                //用户点击了ok
                tb_show.Text = "你点了“是”";
            }
            else if (mbr==MessageBoxResult.No)
            {
                tb_show.Text = "你点了“否”";
            }
            else
            {
                tb_show.Text = "你点了“取消”";
            }
        }
    }
}
