using iassetTechnicalTest.GlobalWeatherServiceReference;
using iassetTechnicalTest.Models;
using iassetTechnicalTest.Services;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace iassetTechnicalTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<IWeatherService, WeatherService>();
            container.RegisterType<IGlobalWeatherService, GlobalWeatherService>();
            container.RegisterType<IOpenWeatherMapService, OpenWeatherMapService>();
            container.RegisterInstance(new GlobalWeatherSoapClient());
            container.RegisterInstance(new OpenWeatherMapConfig
            {
                Url = ConfigurationManager.AppSettings["OpenWeatherMapConfig:Url"],
                APPID = ConfigurationManager.AppSettings["OpenWeatherMapConfig:APPID"]
            });
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}