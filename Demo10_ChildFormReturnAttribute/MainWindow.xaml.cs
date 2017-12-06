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

namespace Demo10_ChildFormReturnAttribute
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
            ChildForm cf = new ChildForm();
            cf.tb_get.Text = tb_send.Text;
            cf.ShowDialog();

            tb_show.Text = cf.public_string;
        }
    }
}
