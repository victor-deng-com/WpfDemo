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

namespace Demo10_ChildFormReturnAttribute
{
    /// <summary>
    /// ChildForm.xaml 的交互逻辑
    /// </summary>
    public partial class ChildForm : Window
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        public string public_string { get; set; }

        private void Window_Closed(object sender, EventArgs e)
        {
            public_string = tb_childForm.Text;
        }
    }
}
