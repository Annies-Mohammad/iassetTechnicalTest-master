using iassetTechnicalTest.Services;
using System.Web.Http;

namespace iassetTechnicalTest.WebAPI
{
    [V1ExceptionFilter]
    [RoutePrefix("v1/city")]
    public class WeatherCityV1Controller : ApiController
    {
        readonly private IWeatherService _weatherService;
        public WeatherCityV1Controller(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("{cityName}/{countryName}/weather")]
        public IHttpActionResult Get(string cityName, string countryName)
        {
            var result= _weatherService.GetCityWeatherCondition(cityName, countryName);
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
