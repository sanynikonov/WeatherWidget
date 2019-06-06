using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace WeatherWidget
{
    class DBHandler
    {
        private const string ConnectionString = "Data Source=weather.db;Version=3;";

        public IEnumerable<WeatherDay> GetWeatherDays(string table)
        {
            string txtQuery = $"SELECT * FROM {table}";
            List<WeatherDay> weather = new List<WeatherDay>();
            using (SQLiteConnection c = new SQLiteConnection(ConnectionString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(txtQuery, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        
                        if (rdr.HasRows)
                        {
                            int id;
                            DateTime date;
                            double temperature;
                            double pressure;
                            double speedOfWind;
                            double windDirection;
                            string sky;
                            WeatherDay weatherDay;
                            bool rainy;
                            bool snowy;
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["id"]);
                                date = Convert.ToDateTime((string)rdr["date"]);
                                temperature = (double)rdr["temperature"];
                                pressure = (double)rdr["pressure"];
                                windDirection = (double)rdr["wind"];
                                speedOfWind = (double)rdr["speedOfWind"];
                                sky = (string)rdr["sky"];
                                rainy = sky == "cdn.apixu.com/weather/64x64/day/302.png";
                                snowy = temperature < 10.0 ? true : false;
                                weatherDay = new WeatherDay(id, date, temperature, pressure, speedOfWind, windDirection, sky, rainy, snowy);
                                weather.Add(weatherDay);
                            }
                        }
                    }
                }
            }
            return weather;
        }
    }
}
