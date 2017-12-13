using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo20_ButtonLeftClickMenu
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            my_start();
        }
        ContextMenu aMenu;
        private void my_start()
        {
            //btn_code.Initialized += btn_code_Initialized;
            btn_code.Click += btn_code_Click;

            aMenu = new ContextMenu();
            MenuItem deleteMenu = new MenuItem();
            deleteMenu.Header = "删除";
            deleteMenu.Click += MenuItem_Click;
            aMenu.Items.Add(deleteMenu);
            btn_code.ContextMenu = aMenu;
        }

        private void btn_code_Initialized(object sender, EventArgs e)
        {
            //设置右键菜单为null
            this.btn_code.ContextMenu = null;
        }
        private void btn_code_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            //目标
            aMenu.PlacementTarget = btn;
            //位置
            aMenu.Placement = PlacementMode.Bottom;
            //显示菜单
            aMenu.IsOpen = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("你点击了我");
        }

        private void btnMenu_Initialized(object sender, EventArgs e)
        {
            //设置右键菜单为null
            this.btnMenu.ContextMenu = null;
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            //目标
            this.contextMenu.PlacementTarget = this.btnMenu;
            //位置
            this.contextMenu.Placement = PlacementMode.Bottom;
            //显示菜单
            this.contextMenu.IsOpen = true;
        }

    }
}
