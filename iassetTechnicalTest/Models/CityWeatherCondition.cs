using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iassetTechnicalTest.Models
{
    public class CityWeatherCondition
    {
        public double DewPoint { get; set; }
        public string Location { get; set; }
        public double Pressure { get; set; }
        public double RelativeHumidity { get; set; }
        public string SkyConditions { get; set; }
        public double Temperature { get; set; }
        public string Time { get; set; }
        public double Visibility { get; set; }
        public double Wind { get; set; }
    }
}