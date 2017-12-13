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


namespace Demo24_ButtonShortcutKey
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

        //private void btn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.Control == true && e.KeyCode == Keys.J)
        //    {
        //        //btn.PerformClick();
        //    }
        //}

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("你点击了我");
        }

        private void btn_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl)) && e.KeyboardDevice.IsKeyDown(Key.A))
            {
                //代码触发点击事件
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl)) && e.KeyboardDevice.IsKeyDown(Key.A))
            {
                //代码触发点击事件
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl)) && e.KeyboardDevice.IsKeyDown(Key.Enter))
            {
                //代码触发点击事件
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
