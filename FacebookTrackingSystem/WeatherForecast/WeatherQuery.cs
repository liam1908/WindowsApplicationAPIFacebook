using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FacebookTrackingSystem.WeatherForecast
{
    public class WeatherQuery
    {
        /*Query Codde*/
        public string GenerateQueryCode (object st)
        {
            string kq;
            switch (st)
            {
                case "City":
                    kq = "q";
                    break;
                case "ZIP":
                    kq = "zip";
                    break;
                case "ID":
                    kq = "id";
                    break;
                default:
                    kq = "q";
                    break;
            }
            return kq;
        }


        string weatherData;


        /*Export Wheather Forecast Data to Str*/

        public string ExportWheatherData(string locate, string querycode)
        {
            
            string url = WeatherData.ForecastUrl.Replace("@LOC@", locate);
            url = url.Replace("@QUERY@", querycode);
            using (WebClient client = new WebClient())
            {

                try
                {
                    weatherData = ProcessXMLToStr(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    MessageBox.Show($"Error in WebClient\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return weatherData;
        }
        
        private string ProcessXMLToStr (string xml)
        {
            string finalstring;
            char degreeC = (char)176;
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);
            /*Mẫu bản tin
             * Welcome to our Wether Forecast Program
             * This Weather Forecase for: City Name, 
             * 
             */
            finalstring = "Welcome to our Weather Forecast Program\n";
            finalstring += "This Weaather Forecast for the next 4 days (Update every 3 hour/day), Weather Source Data: OpenWeatherMap\n";
            finalstring += "This Weather Forecast for: ";
            /*Khai báo 1 XmlNode*/
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            finalstring += loc_node.SelectSingleNode("name").InnerText;
            finalstring += ", ";
            finalstring += loc_node.SelectSingleNode("country").InnerText;
            finalstring += "\n";
            finalstring += "------------------------------------------\n";
            finalstring += $"Temperator Unit: {degreeC}C\n";
            string substring ="";
            string previousdayofWeek = "A";
            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {

                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);
                if (previousdayofWeek != time.DayOfWeek.ToString())
                {
                    substring += "\n" + time.ToLongDateString() + "\n";
                }
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;
                XmlNode status_node = time_node.SelectSingleNode("symbol");
                string status = status_node.Attributes["name"].Value;
                substring += time.ToShortTimeString() + ": " + temp + $"{degreeC}C, " + status + "\n";
                previousdayofWeek = time.DayOfWeek.ToString();
            }
            finalstring += substring;

            return finalstring;
        }
    }
}
