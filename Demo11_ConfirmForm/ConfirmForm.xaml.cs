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

namespace Demo11_ConfirmForm
{
    /// <summary>
    /// ConfirmForm.xaml 的交互逻辑
    /// </summary>
    public partial class ConfirmForm : Window
    {
        public ConfirmForm()
        {
            InitializeComponent();
        }

        //public bool status { get; set; }
        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btn_disconfirm_Click(object sender, RoutedEventArgs e)
        {
            //赋值无效！！！接收到的依旧是false
            DialogResult = null;
            Close();
        }
    }
}
