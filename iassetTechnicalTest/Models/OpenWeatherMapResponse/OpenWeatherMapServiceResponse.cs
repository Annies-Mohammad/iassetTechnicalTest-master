using iassetTechnicalTest.Models.OpenWeatherMapResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iassetTechnicalTest.Models
{
    public class OpenWeatherMapServiceResponse
    {
        public Coordinate Coord { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public double Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
        public double Dt { get; set; }
        public Sys Sys { get; set; }
    }
}

/*
 
{
	"coord": {
		"lon": 151.21,
		"lat": -33.87
	},
	"weather": [{
		"id": 802,
		"main": "Clouds",
		"description": "scattered clouds",
		"icon": "03d"
	}],
	"base": "stations",
	"main": {
		"temp": 299.15,
		"pressure": 1008,
		"humidity": 69,
		"temp_min": 299.15,
		"temp_max": 299.15
	},
	"visibility": 10000,
	"wind": {
		"speed": 10.3,
		"deg": 180
	},
	"clouds": {
		"all": 40
	},
	"dt": 1480926600,
	"sys": {
		"type": 1,
		"id": 8233,
		"message": 0.0126,
		"country": "AU",
		"sunrise": 1480876621,
		"sunset": 1480928107
	},
	"id": 2147714,
	"name": "Sydney",
	"cod": 200
}

     */
