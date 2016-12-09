using iassetTechnicalTest.Services;
using System.Linq;
using System.Web.Http;

namespace iassetTechnicalTest.WebAPI
{
    [V1ExceptionFilter]
    [RoutePrefix("v1/counteries")]
    public class WeatherCountryV1Controller : ApiController
    {
        readonly private IWeatherService _weatherService;
        public WeatherCountryV1Controller(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("{countryName}/cities")]
        public IHttpActionResult Get(string countryName)
        {
            var cities = _weatherService.GetCities(countryName);
            if (cities==null || cities.Count()==0)
            {
                return NotFound();
            }
            return Ok(_weatherService.GetCities(countryName));
        }
    }
}
