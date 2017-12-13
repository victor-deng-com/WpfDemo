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

namespace Demo19_RichTextBoxAutoSize
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mystart();
        }

        public void mystart()
        {
            //rtb_detail.Width = tb_detail.Width;

            TextBlock tb = new TextBlock();
            tb.Text= "hello!hello!hello!hello!hello!hello!hello!hello!";
            double w1=tb.Width;

            TextBox tb_hide = new TextBox();
            tb_hide.Text = "hello!hello!hello!hello!hello!hello!hello!hello!";
            double w = tb_hide.Width;

            //Grid 表格，用于留言详情的布局
            Grid grid_messageDetail_buyer = new Grid();
            grid_messageDetail_buyer.Margin = new Thickness(10, 2, 80, 2);

            RowDefinition rd_messageDetail_buyer1 = new RowDefinition();
            RowDefinition rd_messageDetail_buyer2 = new RowDefinition();
            grid_messageDetail_buyer.RowDefinitions.Add(rd_messageDetail_buyer1);
            grid_messageDetail_buyer.RowDefinitions.Add(rd_messageDetail_buyer2);
            ColumnDefinition cd_messageDetail_buyer = new ColumnDefinition();
            grid_messageDetail_buyer.ColumnDefinitions.Add(cd_messageDetail_buyer);

            //TextBlock 发送者姓名和时间
            TextBlock tb_buyer = new TextBlock();
            tb_buyer.Text = "Gary Tang | 2017-12-07 15:03:22";
            BrushConverter bc = new BrushConverter();
            Brush bru = bc.ConvertFromInvariantString("#666666") as Brush;
            tb_buyer.Foreground = bru;
            Grid.SetRow(tb_buyer, 0);

            grid_messageDetail_buyer.Children.Add(tb_buyer);

            //StackPanel 用于建立信息气泡，限定文字的范围
            StackPanel sp_messageBox = new StackPanel();
            Grid.SetRow(sp_messageBox, 1);
            Image img_point = new Image();
            img_point.Source = new BitmapImage(new Uri("/Resources/Images/BubblePoint_gray.png", UriKind.Relative));
            img_point.Width = 10;
            img_point.Margin = new Thickness(20, 0, 0, 0);
            img_point.VerticalAlignment = VerticalAlignment.Bottom;
            img_point.HorizontalAlignment = HorizontalAlignment.Left;
            sp_messageBox.Children.Add(img_point);

            //StackPanel 用于使富文本编辑框自适应尺寸
            StackPanel sp_messageDetail = new StackPanel();
            sp_messageDetail.Orientation = Orientation.Horizontal;

            //RichTextBox富文本编辑框
            AutoSizeRichTextBox rtb_messageDetail = new AutoSizeRichTextBox();
            rtb_messageDetail.IsReadOnly = true;
            rtb_messageDetail.AcceptsReturn = true;
            //通过隐藏的textbox来获取宽度。
            //TextBox tb_hide = new TextBox();
            //tb_hide.MaxWidth = 800;

            //rtb_messageDetail.MinWidth = 50;
            //rtb_messageDetail.MaxWidth = 500;
            BrushConverter bc_gray = new BrushConverter();
            Brush bru_gray = bc_gray.ConvertFromInvariantString("#e6e6e6") as Brush;
            rtb_messageDetail.BorderBrush = bru_gray;
            rtb_messageDetail.Background = bru_gray;
            BrushConverter bc_white = new BrushConverter();
            Brush bru_white = bc_white.ConvertFromInvariantString("#000000") as Brush;
            rtb_messageDetail.Foreground = bru_white;

            //富文本编辑框内的文字内容和图片
            string detailText = "hello!hello!hello!hello!hello!hello!hello!hello!";
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run(detailText);
            p.Inlines.Add(r);//Run级元素添加到Paragraph元素的Inline
            doc.Blocks.Add(p);//Paragraph级元素添加到流文档的块级元素
            rtb_messageDetail.Document = doc;
            Image message_image = new Image();
            message_image.Source = new BitmapImage(new Uri("http://ae01.alicdn.com/kf/HTB1u.UKa7fb_uJkSnfoq6z_epXar.jpg"));
            
            InlineUIContainer container = new InlineUIContainer(message_image);
            Paragraph paragraph = new Paragraph(container);
            rtb_messageDetail.Document.Blocks.Add(paragraph);

            sp_messageDetail.Children.Add(rtb_messageDetail);

            sp_messageBox.Children.Add(sp_messageDetail);

            grid_messageDetail_buyer.Children.Add(sp_messageBox);

            sp_messageDetail_outside.Children.Add(grid_messageDetail_buyer);
        }

    }
}
