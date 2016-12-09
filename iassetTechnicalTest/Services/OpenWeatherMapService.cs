using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iassetTechnicalTest.Models;
using System.Net.Http;

namespace iassetTechnicalTest.Services
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        readonly private OpenWeatherMapConfig _config;
        public OpenWeatherMapService(OpenWeatherMapConfig config)
        {
            _config = config;
        }

        public IEnumerable<string> GetCities(string countryName)
        {
            throw new NotImplementedException();
        }

        public CityWeatherCondition GetCityWeatherCondition(string cityName, string countryName)
        {
            CityWeatherCondition weatherResult = null;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"{_config.Url}?q={cityName}&APPID={_config.APPID}").Result;
                var weather = response.Content.ReadAsAsync<OpenWeatherMapServiceResponse>().Result;
                if (weather != null)
                {
                    weatherResult = new CityWeatherCondition
                    {
                        Location = weather.Name,
                        Time = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(weather.Dt).ToShortTimeString(),
                        Wind = weather.Wind.Speed,
                        Visibility = weather.Visibility,
                        SkyConditions = weather.Weather.FirstOrDefault()?.Description,
                        Temperature = weather.Main.Temp,
                        DewPoint = weather.Main.Humidity,
                        RelativeHumidity = weather.Main.Humidity,
                        Pressure = weather.Main.Pressure
                    };
                }
            }
            return weatherResult;
        }
    }
}