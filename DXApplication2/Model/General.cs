using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;

namespace DXApplication2.Model
{
    public class General
    {
        public string Serial { get; set; }
        public string SampleName { get; set; }
        public DateTime? Date { get; set; }
        public List<Dimensions> Data { get; set; }
        public Image? Image { get; set; }


        // Constructor
        public General(string serial, string name, List<Dimensions> data, DateTime? date, Image? img)
        {
            Serial = serial;
            SampleName = name;
            Data = data;
            Date = date;
            Image = img;
        }   
    }
}
