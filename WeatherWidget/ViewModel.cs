using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;

namespace WeatherWidget
{
    class ViewModel : INotifyPropertyChanged
    {
        

        private DBHandler db = new DBHandler();
        private List<WeatherDay> OpenWeather;
        private List<WeatherDay> Apixu;
        private List<WeatherDay> AverageWeather;
        private List<WeatherDay> SelectedSource;
        

        private Predicate<DateTime> dateTime;
        private TimeSpan refreshing;

        public RelayCommand OpenWeatherCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    SelectedWeatherDay = OpenWeather[0];
                });
            }
        }
        public RelayCommand ApixuCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    SelectedWeatherDay = Apixu[0];
                });
            }
        }
        public RelayCommand AverageWeatherCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    SelectedWeatherDay = AverageWeather[0];
                });
            }
        }

        public RelayCommand NextDayCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    //SelectedSource = 
                });
            }

        }

        private WeatherDay selectedWeatherDay;
        public WeatherDay SelectedWeatherDay
        {
            get { return selectedWeatherDay; }
            set
            {
                selectedWeatherDay = value;
                OnPropertyChanged("SelectedWeatherDay");
            }
        }

        private void UpdateWeather(object obj)
        {
            OpenWeather = new List<WeatherDay>(db.GetWeatherDays("openweather"));
            SelectedWeatherDay = new WeatherDay(
                OpenWeather[0].Id,
                OpenWeather[0].Date,
                OpenWeather[0].Temperature,
                OpenWeather[0].Pressure,
                OpenWeather[0].WindDirection,
                OpenWeather[0].SpeedOfWind,
                OpenWeather[0].Sky,
                OpenWeather[0].Rainy, 
                OpenWeather[0].Snowy);
            Apixu = new List<WeatherDay>(db.GetWeatherDays("apixu"));
            UpdateAverage();
        }

        private void UpdateAverage()
        {
            AverageWeather.Clear();

            int id;
            DateTime date;
            double temperature;
            double pressure;
            double speedOfWind;
            double windDirection;
            string sky;
            bool rainy;
            bool snowy;
            WeatherDay weatherDay;

            for (int i = 0; i < OpenWeather.Count; i++)
            {
                id = OpenWeather[i].Id;
                date = OpenWeather[i].Date;
                temperature = (OpenWeather[i].Temperature + Apixu[i].Temperature) / 2;
                pressure = (OpenWeather[i].Pressure + Apixu[i].Pressure) / 2;
                speedOfWind = (OpenWeather[i].SpeedOfWind + Apixu[i].SpeedOfWind) / 2;
                windDirection = (OpenWeather[i].WindDirection + Apixu[i].WindDirection) / 2;
                sky = OpenWeather[i].Sky;
                rainy = OpenWeather[i].Rainy || Apixu[i].Rainy;
                snowy = OpenWeather[i].Snowy || Apixu[i].Snowy;
                weatherDay = new WeatherDay(id, date, temperature, pressure, speedOfWind, windDirection, sky, rainy, snowy);
                AverageWeather.Add(weatherDay);
            }
        }

        public ViewModel()
        {
            TimerCallback tc = new TimerCallback(UpdateWeather);
            long startTime = DateTime.Now.Millisecond / 10800000 * 10800000;
            Timer timer = new Timer(tc, null, startTime, 10800000);
            AverageWeather = new List<WeatherDay>();
            UpdateWeather(null);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
