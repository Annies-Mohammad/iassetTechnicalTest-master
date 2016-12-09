using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iassetTechnicalTest.Models;

namespace iassetTechnicalTest.Services
{
    public class WeatherService : IWeatherService
    {
        readonly private IGlobalWeatherService _globalWeatherService;
        readonly private IOpenWeatherMapService _openWeatherMapService;

        public WeatherService(
            IGlobalWeatherService globalWeatherService,
            IOpenWeatherMapService openWeatherMapService)
        {
            _globalWeatherService = globalWeatherService;
            _openWeatherMapService = openWeatherMapService;
        }


        public IEnumerable<string> GetCities(string countryName)
        {
            return _globalWeatherService.GetCities(countryName);
        }

        public CityWeatherCondition GetCityWeatherCondition(string cityName, string countryName)
        {
            var weatherCondition = GetCityWeatherConditionByGlobalWeatherService(cityName, countryName);
            if (!weatherCondition.Success)
            {
                weatherCondition = GetCityWeatherConditionByOpenWeatherMapService(cityName, countryName);
            }
            return weatherCondition.WeatherCondition;
        }

        public CityWeatherResponseStatus GetCityWeatherConditionByGlobalWeatherService(string cityName, string countryName)
        {
            try
            {
                var weatherCondition = _globalWeatherService.GetCityWeatherCondition(cityName, countryName);
                return new CityWeatherResponseStatus(weatherCondition);
            }
            catch
            {
                return new CityWeatherResponseStatus(null);
            }
        }

        public CityWeatherResponseStatus GetCityWeatherConditionByOpenWeatherMapService(string cityName, string countryName)
        {
            try
            {
                var weatherCondition = _openWeatherMapService.GetCityWeatherCondition(cityName, countryName);
                return new CityWeatherResponseStatus(weatherCondition);
            }
            catch
            {
                return new CityWeatherResponseStatus(null);
            }
        }
    }
}