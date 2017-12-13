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

namespace Demo16_ScrollViewer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DefinedInitialization();
        }

        private void DefinedInitialization()
        {
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Height = 50;
                btn.Content = "模拟按钮测试"+i;
                sp_menu.Children.Add(btn);
            }
        }
    }
}
