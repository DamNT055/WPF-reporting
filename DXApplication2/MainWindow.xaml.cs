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
            var defaultDims = new (double length, double width, double height)[] { (10.0, 5.0, 2.0) };
            this.ShowReport("SN-0001", "Sample A", img, DateTime.Now, defaultDims);
        }

        public void ShowReport(string serial, string sampleName, Image img, DateTime date, (double length, double width, double height)[] dimensionsArray)
        {
            var dimensionsList = (dimensionsArray ?? Array.Empty<(double length, double width, double height)>()).Select(d => new Dimensions(d.length, d.width, d.height))
                        .ToList();

            var safeImage = img ?? new Bitmap(1, 1);
            var general = new General(serial, sampleName, dimensionsList, date, safeImage);
            var root = new { General = general };

            ObjectDataSource objectSource = new() { DataSource = root };
            var report = new XtraReportInstance()
            {
                DataSource = objectSource,
                DataMember = "General.Data"
            };
            viewer.DocumentSource = report;
        }
    }
}
