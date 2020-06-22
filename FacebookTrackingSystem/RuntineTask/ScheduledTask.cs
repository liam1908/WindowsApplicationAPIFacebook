using FacebookTrackingSystem.Facebook;
using FacebookTrackingSystem.FacebookMain;
using FacebookTrackingSystem.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
//using System.Windows.Forms;

namespace FacebookTrackingSystem.RuntineTask
{
    public class ScheduledTask : IDisposable
    {
        private readonly Timer clock;


        //Giá trị nhận vào khi muốn set Schedule
        public static string cityloc, querycode;
        public static int hourset, minset, secset;
        public ScheduledTask()
        {
            clock = new Timer();
            clock.Interval = 1000; // runs every second just like a normal clock            
        }

        public void Start()
        {
            clock.Elapsed += Clock_Elapsed;
            this.clock.Start();
        }

        public void Stop()
        {
            clock.Elapsed -= Clock_Elapsed;
            this.clock.Stop();
        }
        private void Clock_Elapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;

            // Task thực hiện khi đúng thời gian set
            if ((now.TimeOfDay >= new TimeSpan(hourset, minset, secset)) && (now.TimeOfDay <= new TimeSpan(hourset, minset, secset+1)))
            {
                ScheduleWeatherForecast(cityloc, querycode);
            }
         }

        public void Dispose()
        {
            if (this.clock != null)
            {
                this.clock.Dispose();
            }
        }

        //Tạo 2 instance cho weatherQuery và facebookClient
        WeatherQuery weatherQuery = new WeatherQuery();
        FacebookClient facebookClient = new FacebookClient();
        private async void ScheduleWeatherForecast(string loc, string querycode)
        {
            string kq;
            PostingPara para = new PostingPara();
            para.access_token = FacebookSettings.PageAccessToken;
            para.message = weatherQuery.ExportWheatherData(loc, querycode);
            para.link = WeatherData.weatherWallpaperLink;
            var postStatusTask = facebookClient.PostOnWallPage(FacebookSettings.PageID, para);
            await postStatusTask;
            var postResultTask = postStatusTask.Result;
            //if (postResultTask.errorCode == null)
            //{
            //    return kq= $"Bài viết đăng thành công!!!\nID bài viết {postResultTask.postID}";
            //}
            //else
            //{
            //    return kq= $"\nMã lỗi: {postResultTask.errorCode}\nMessage: {postResultTask.errorMessage}";
            //}
        }
    }
}
