using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTrackingSystem.WeatherForecast
{
    public class WeatherData
    {
        
        public static string OpenWeatherMapAT = "c6004c6203311c27d0f94739266c5043";
        public static string ForecastUrl =
             "http://api.openweathermap.org/data/2.5/forecast?" +
             "@QUERY@=@LOC@&mode=xml&units=metric&APPID=" + OpenWeatherMapAT;

        public static string weatherWallpaperLink = "https://images.unsplash.com/photo-1591974425386-03d781e05088?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=967&q=80";


    }
}
