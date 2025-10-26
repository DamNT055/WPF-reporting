using System;
using System.Collections.Generic;

namespace DXApplication2.Model
{
    public class General
    {
        // Serial number
        public string Serial { get; set; }

        // Sample name
        public string SampleName { get; set; }
        public List<Dimensions> Data { get; set; }


        // Constructor
        public General(string serial, string name, List<Dimensions> data)
        {
            Serial = serial;
            SampleName = name;
            Data = data;
        }   
    }
}
