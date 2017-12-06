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
using System.Windows.Forms;

namespace Demo15_NotificationBarIcon
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowNotifyIcon();
        }
        #region 通知栏
        System.Windows.Forms.NotifyIcon notifyIcon = null;

        private void ShowNotifyIcon()
        {
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.notifyIcon.BalloonTipText = "云客CRM 服务正在运行..."; //设置程序启动时显示的文本  
            this.notifyIcon.Text = "云客CRM 服务";//最小化到托盘时，鼠标悬停时显示的文本  
            this.notifyIcon.Icon = new System.Drawing.Icon("notifyIcon.ico");//程序图标  
            this.notifyIcon.Visible = true;

            //右键菜单--打开菜单项  
            System.Windows.Forms.MenuItem open = new System.Windows.Forms.MenuItem("Open");
            open.Click += new EventHandler(ShowWindow);
            //右键菜单--退出菜单项  
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("Exit");
            exit.Click += new EventHandler(CloseWindow);
            //关联托盘控件  
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { open, exit };
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);

            notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;
            this.notifyIcon.ShowBalloonTip(1000);
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            /* 
             * 这一段代码需要解释一下: 
             * 窗口正常时双击图标执行这段代码是这样一个过程： 
             * this.Show()-->WindowState由Normail变为Minimized-->Window_StateChanged事件执行(this.Hide())-->WindowState由Minimized变为Normal-->窗口隐藏 
             * 窗口隐藏时双击图标执行这段代码是这样一个过程： 
             * this.Show()-->WindowState由Normail变为Minimized-->WindowState由Minimized变为Normal-->窗口显示 
             */
            this.WindowState = WindowState.Minimized;
            this.WindowState = WindowState.Normal;
            this.Show();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            //窗口最小化时隐藏任务栏图标  
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void ShowWindow(object sender, EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Visible;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        private void HideWindow(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

        private void Window_Closed(object sender, EventArgs e)
        {
            this.notifyIcon.Visible = false;
        }

        private void btn_hide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            
        }
    }
}
