using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Demo18_RichTextBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //my_test();
            my_start();
        }

        private void my_test()
        {
            Image img = new Image();
            img.Source= new BitmapImage(new Uri("img_bg.png", UriKind.Relative));
            grid_window.Children.Add(img);
        }

        private void my_start()
        {
            string myText = "hello!";
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run(myText);
            p.Inlines.Add(r);//Run级元素添加到Paragraph元素的Inline
            doc.Blocks.Add(p);//Paragraph级元素添加到流文档的块级元素
            rtb.Document = doc;

            ////获取程序运行的地址
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            Image image = new Image();
            //image.Source = new BitmapImage(new Uri(path + "img_bg.png"));
            //http://ae01.alicdn.com/kf/HTB1u.UKa7fb_uJkSnfoq6z_epXar.jpg
            
            image.Source= new BitmapImage(new Uri("http://ae01.alicdn.com/kf/HTB1u.UKa7fb_uJkSnfoq6z_epXar.jpg"));
            image.Width = 50;
            InlineUIContainer container = new InlineUIContainer(image);
            Paragraph paragraph = new Paragraph(container);
            rtb.Document.Blocks.Add(paragraph);

        }

    }
}
