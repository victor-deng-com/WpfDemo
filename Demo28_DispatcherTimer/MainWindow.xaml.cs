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


using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Drawing;

namespace Demo28_DispatcherTimer
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

        System.Windows.Threading.DispatcherTimer readDataTimer = new System.Windows.Threading.DispatcherTimer();

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            readDataTimer.Start();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            readDataTimer.Stop();
            notifyIcon.Icon = normal;
        }


        System.Windows.Forms.NotifyIcon notifyIcon;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Text = "云客CRM 服务";//最小化到托盘时，鼠标悬停时显示的文本  
            notifyIcon.Icon = normal;//程序图标  
            notifyIcon.Visible = true;

            readDataTimer.Tick += new EventHandler(timeCycle);
            readDataTimer.Interval = new TimeSpan(0,0,0,0,300);
        }
        //icon图标定义
        private Icon blank = Properties.Resources.blank;
        private Icon normal = Properties.Resources.notifyIcon;
        private void timeCycle(object sender, EventArgs e)
        {
            if (notifyIcon.Icon != normal)
                notifyIcon.Icon = normal;
            else
                notifyIcon.Icon = blank;
        }

    }
}
