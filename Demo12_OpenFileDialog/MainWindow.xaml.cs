using Microsoft.Win32;
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

namespace Demo12_OpenFileDialog
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

        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|PNG图片|*.png|视频|*.avi|所有文件|*.*";
            if (ofd.ShowDialog() == true)
            {
                string file_name = ofd.FileName;//打开的文件名
                MessageBox.Show("你打开的文件名："+file_name);
            }
            else
            {
                MessageBox.Show("你取消了打开文件");
            }


        }

        private void btn_open_img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG|*.jpg|PNG图片|*.png|GIF|*.gif";
            if (ofd.ShowDialog() == true)
            {
                string file_name = ofd.FileName;//打开的文件名
                image.Source = new BitmapImage(new Uri(file_name));
            }
        }
    }
}
