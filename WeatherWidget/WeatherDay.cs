using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWidget
{
    class WeatherDay : INotifyPropertyChanged
    {
        private int id;
        private DateTime date;
        private double temperature;
        private double pressure;
        private double windDirection;
        private double speedOfWind;
        private string sky;
        private bool rainy;
        private bool snowy;

        public WeatherDay(int id, DateTime date, double temperature, double pressure, double speedOfWind, double windDirection, string sky, bool rainy, bool snowy)
        {
            Id = id;
            Date = date;
            Temperature = temperature;
            Pressure = pressure;
            SpeedOfWind = speedOfWind;
            WindDirection = windDirection;
            Sky = sky;
            Rainy = rainy;
            Snowy = snowy;
        }

        public bool Snowy
        {
            get { return snowy; }
            set
            {
                snowy = value;
                OnPropertyChanged("Snowy");
            }
        }

        public bool Rainy
        {
            get { return rainy; }
            set
            {
                rainy = value;
                OnPropertyChanged("Rainy");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public double Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public double Pressure
        {
            get { return pressure; }
            set
            {
                pressure = value;
                OnPropertyChanged("Pressure");
            }
        }

        public double SpeedOfWind
        {
            get { return speedOfWind; }
            set
            {
                speedOfWind = value;
                OnPropertyChanged("SpeedOfWind");
            }
        }

        public double WindDirection
        {
            get { return windDirection; }
            set
            {
                windDirection = value;
                OnPropertyChanged("WindDirection");
            }
        }

        public string Sky
        {
            get { return sky; }
            set
            {
                sky = value;
                OnPropertyChanged("Sky");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
