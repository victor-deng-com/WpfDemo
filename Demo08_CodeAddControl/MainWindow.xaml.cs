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

namespace Demo08_CodeAddControl
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                grid_Checkerboard.ColumnDefinitions.Add(cd);

                RowDefinition rd = new RowDefinition();
                grid_Checkerboard.RowDefinitions.Add(rd);
            }

            Random rd_num = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Button btn = new Button();
                    //btn.Content =i+","+j;

                    //Grid.SetRow(btn,i);
                    //Grid.SetColumn(btn,j);

                    //grid_Checkerboard.Children.Add(btn);
                    //1<=rb_num<10
                    int img_num=rd_num.Next(1,10);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("Images/"+img_num+".png",UriKind.Relative));

                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);

                    grid_Checkerboard.Children.Add(img);
                }
            }

        }
    }
}
