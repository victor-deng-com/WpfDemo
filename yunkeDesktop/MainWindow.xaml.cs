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

namespace yunkeDesktop
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
            ColumnDefinition cd = new ColumnDefinition();
            grid_buyer.ColumnDefinitions.Add(cd);
            for (int i = 0; i < 10; i++)
            {
                RowDefinition rd = new RowDefinition();
                grid_buyer.RowDefinitions.Add(rd);
            }

            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Content = "模拟按钮 "+i;

                Grid.SetRow(btn, i);
                Grid.SetColumn(btn, 0);

                grid_buyer.Children.Add(btn);
            }
        }
    }
}
