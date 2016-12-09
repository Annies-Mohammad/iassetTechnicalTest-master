using iassetTechnicalTest.Models;
using iassetTechnicalTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iassetTechnicalTest.Tests
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// This test checks if GlobalWeatherService failed then WeatherService uses OpenWeatherMapService
        /// </summary>
        [TestMethod]
        public void If_GlobalWeather_Failed_Then_Use_OpenWeatherMap() 
        {
            var mockedGlobalWeatherService = new Mock<IGlobalWeatherService>();
            mockedGlobalWeatherService.Setup(s => s.GetCityWeatherCondition(It.IsAny<string>(), It.IsAny<string>())).Throws(new GlobalWeatherDataNotFoundException());
            var mockedIOpenWeatherMapService = new Mock<IOpenWeatherMapService>();
            mockedIOpenWeatherMapService.Setup(s => s.GetCityWeatherCondition(It.IsAny<string>(), It.IsAny<string>())).Returns(new CityWeatherCondition());
            IWeatherService service = new WeatherService(mockedGlobalWeatherService.Object, mockedIOpenWeatherMapService.Object);
            service.GetCityWeatherCondition("", "");
            mockedIOpenWeatherMapService.Verify(s => s.GetCityWeatherCondition(It.IsAny<string>(), It.IsAny<string>()), Times.Once()); 
        }

        /// <summary>
        /// This test checks if GlobalWeatherService succeeded then WeatherService does not use OpenWeatherMapService
        /// </summary>

        [TestMethod]
        public void If_GlobalWeather_Not_Failed_Then_Not_Use_OpenWeatherMap() 
        {
            var mockedGlobalWeatherService = new Mock<IGlobalWeatherService>();
            mockedGlobalWeatherService.Setup(s => s.GetCityWeatherCondition(It.IsAny<string>(), It.IsAny<string>())).Returns(new CityWeatherCondition());
            var mockedIOpenWeatherMapService = new Mock<IOpenWeatherMapService>();
            mockedIOpenWeatherMapService.Setup(s => s.GetCityWeatherCondition(It.IsAny<string>(), It.IsAny<string>())).Returns(new CityWeatherCondition());
            IWeatherService service = new WeatherService(mockedGlobalWeatherService.Object, mockedIOpenWeatherMapService.Object);
            service.GetCityWeatherCondition("", "");
            mockedIOpenWeatherMapService.Verify(s => s.GetCityWeatherCondition(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }
    }
}
