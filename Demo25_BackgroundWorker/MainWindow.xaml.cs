using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace Demo25_BackgroundWorker
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
        BackgroundWorker bw;
        private void btn_backgroundWorker_Click(object sender, RoutedEventArgs e)
        {
            bw = new System.ComponentModel.BackgroundWorker();//创建BackgroundWorker对象实例  
            bw.DoWork += new System.ComponentModel.DoWorkEventHandler(bw_DoWork);//订阅DoWork事件  
            bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bw_ProgressChanged);//订阅报告进程事件
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();//开始执行后台操作
        }

        void bw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;//获取进度百分比  
            this.label2.Content = (e.ProgressPercentage.ToString() + "%");
        }

        
        void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                this.bw.ReportProgress(i);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
