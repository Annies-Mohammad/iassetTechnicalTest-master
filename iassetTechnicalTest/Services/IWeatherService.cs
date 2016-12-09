using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iassetTechnicalTest.Models;

namespace iassetTechnicalTest.Services
{
    public interface IWeatherService
    {
        IEnumerable<string> GetCities(string countryName);
        CityWeatherCondition GetCityWeatherCondition(string cityName, string countryName);
    }
}
