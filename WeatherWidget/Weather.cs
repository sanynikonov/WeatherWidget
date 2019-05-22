using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWidget
{
    class Weather
    {
        private int id;
        private int date;
        private int temperature;
        private int pressure;
        private double wind;
        private Sky sky;
        private string source; // это с какого сайта взял, подойдёт и другой тип

        
    }

    enum Sky
    {
        Sunny,
        Cloudy,
        Rainy,
        Snowy
    }
}
