using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Xpf.Core;
using DXApplication2.Model;
using DXApplication2.Helper;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public static Image LoadImage()
        {
            string path = System.IO.Path.Combine(@"D:\Dev-TD\WPF-reporting\DXApplication2", "SecondSample_25MHz.Tiff");
            try
            {
                using var fs = File.OpenRead(path);
                using var src = Image.FromStream(fs);
                return new Bitmap(src);
            }
            catch
            {
                return new Bitmap(1, 1);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            var img = LoadImage();
            var defaultDims = new (double length, double width, double height)[] 
            { 
                (10.0, 5.0, 2.0),
                (15.0, 7.5, 3.0),
                (20.0, 10.0, 4.0)
            };
            this.ShowReport("SN-0001", "Sample A", img, DateTime.Now, defaultDims);
        }

        public void ShowReport(string serial, string sampleName, Image img, DateTime date, (double length, double width, double height)[] dimensionsArray)
        {
            var report = ReportService.CreateReport(serial, sampleName, img, date, dimensionsArray);
            viewer.DocumentSource = report;
        }
    }
}
