using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.DataAccess.ObjectBinding;
using DXApplication2.Model;

namespace DXApplication2.Helper
{
    /// <summary>
    /// ReportService creates XtraReportInstance objects from runtime data.
    /// The method below is static for easy use from UI code; it returns a
    /// prepared XtraReportInstance which can be assigned to a viewer's DocumentSource.
    /// </summary>
    public static class ReportService
    {
        public static XtraReportInstance CreateReport(string serial, string sampleName, Image img, DateTime? date, (double length, double width, double height)[] dimensionsArray)
        {
            var dimensionsList = (dimensionsArray ?? Array.Empty<(double length, double width, double height)>())
                .Select(d => new Dimensions(d.length, d.width, d.height))
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

            return report;
        }
    }
}
