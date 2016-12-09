using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iassetTechnicalTest.Models
{
    public class CityWeatherResponseStatus
    {
        public bool Success { get; }
        public CityWeatherCondition WeatherCondition { get; }

        public CityWeatherResponseStatus(CityWeatherCondition weatherCondition)
        {
            WeatherCondition = weatherCondition;
            Success = WeatherCondition != null;
        }
    }
}