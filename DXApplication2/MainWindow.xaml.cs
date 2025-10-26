using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        public MainWindow()
        {
            InitializeComponent();
            // Wrap the list into a root object so the report can bind to General.Data
            // Create a General model instance with Serial and SampleName
            var general = new General("SN-0001", "Sample A", CreateData());
            var root = new { General = general };
            ObjectDataSource objectSource = new() { DataSource = root };
            var report = new XtraReportInstance() { DataSource = objectSource };
            // Bind the Detail band to the collection at General.Data
            report.DataMember = "General.Data";
            viewer.DocumentSource = report;
        }
        public List<Dimensions> CreateData()
        {
            // Sample dimensions data — replace or extend with real values as needed.
            return new List<Dimensions>() {
                new Dimensions(10.0, 5.0, 2.5, 0.5),
                new Dimensions(1, 2, 2.5, 0.5),
            };
        }
        public void ShowReport(ImageSource img, (double length, double width, double height, double depth)[] dimensionsArray)
        {
            List<Dimensions> dimensionsList = new List<Dimensions>();
            foreach (var d in dimensionsArray)
            {
                dimensionsList.Add(new Dimensions(d.length, d.width, d.height, d.depth));
            }

            // Gán dữ liệu cho report — bọc vào root.General.Data và set DataMember
            var general = new DXApplication2.Model.General("SN-0001", "Sample A", dimensionsList);
            ObjectDataSource objectSource = new() { DataSource = new { General = general } };
            var report = new XtraReportInstance()
            {
                DataSource = objectSource
            };
            // Important: bind the detail band to the collection path
            report.DataMember = "General.Data";

            // TODO: bind img vào report nếu cần, ví dụ XRPictureBox
            // report.PictureBox.ImageSource = img;

            viewer.DocumentSource = report;
        }
    }
}
