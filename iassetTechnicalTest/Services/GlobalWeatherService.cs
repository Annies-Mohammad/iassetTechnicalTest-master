using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iassetTechnicalTest.Models;
using iassetTechnicalTest.GlobalWeatherServiceReference;
using System.Xml;
using System.Xml.Serialization;

namespace iassetTechnicalTest.Services
{
    public class GlobalWeatherService : IGlobalWeatherService
    {
        readonly private GlobalWeatherSoapClient _globalWeatherSoapClient;

        public GlobalWeatherService(GlobalWeatherSoapClient client)
        {
            _globalWeatherSoapClient = client;// new GlobalWeatherSoapClient();
        }

        public IEnumerable<string> GetCities(string countryName)
        {
            var request = new GetCitiesByCountryRequest(countryName);
            var citiesByCountryResult = _globalWeatherSoapClient.GetCitiesByCountryAsync(request).Result.GetCitiesByCountryResult;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(citiesByCountryResult);
            XmlNodeList xnList = xml.SelectNodes("/NewDataSet/Table");
            var cities = new List<string>();
            foreach (XmlNode xnode in xnList)
            {
                string cityName = xnode["City"].InnerText;
                cities.Add(cityName);
            }
            return cities.Distinct();
        }

        public CityWeatherCondition GetCityWeatherCondition(string cityName, string countryName)
        {
            var request = new GetWeatherRequest(cityName, countryName);
            var citiesByCountryResult = _globalWeatherSoapClient.GetWeather(request).GetWeatherResult;
            if (citiesByCountryResult == "Data Not Found")
            {
                throw new GlobalWeatherDataNotFoundException();
            }
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(citiesByCountryResult);
            return new CityWeatherCondition();
        }
    }
}