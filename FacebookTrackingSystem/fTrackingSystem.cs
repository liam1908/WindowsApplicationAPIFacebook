using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net;
using System.IO;
using System.Xml;



using FacebookTrackingSystem.FacebookMain;
using FacebookTrackingSystem.Facebook;
using FacebookTrackingSystem.WeatherForecast;
using FacebookTrackingSystem.RuntineTask;

using System.Globalization;
using System.Threading;
using FacebookTrackingSystem.Data;

namespace FacebookTrackingSystem
{
    public partial class fTrackingSystem : Form
    {
        FacebookClient facebookClient = new FacebookClient();
        public fTrackingSystem()
        {
            InitializeComponent();
            dtp_FBASetTime.Format = DateTimePickerFormat.Custom;
            dtp_FBASetTime.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            
        }
        public ScheduledTask scheduler;


        /*Load form - setting up */

        private void fTrackingSystem_Load(object sender, EventArgs e)
        {            
            scheduler = new ScheduledTask();
            scheduler.Start();
            tc_Main.Enabled = false;
            mainMenu_Tool.Enabled = false;
        }
        private void fTrackingSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            scheduler.Stop();
            scheduler.Dispose();
        }



        /*Event*/
        /*Button Event*/

        private async void btn_Connectfb_Click(object sender, EventArgs e)
        {
            FacebookSettings.AppID = txb_AppID.Text;
            FacebookSettings.AppSecret = txb_AppSecret.Text;
            FacebookSettings.UserShortAccessToken = txb_UserAccessToken.Text;
            FacebookSettings.PageName = txb_PageName.Text;

            //Chuyển Short-AT thành Long-live Access Token
            var changeAccessTokenTask = facebookClient.GetAccessToken(FacebookSettings.AppID, FacebookSettings.AppSecret, FacebookSettings.UserShortAccessToken);
            await changeAccessTokenTask;
            var longAccessToken = changeAccessTokenTask.Result;
            FacebookSettings.UserLongAccessToken = longAccessToken.UserAccessToken;

            //Lấy thông tin Account
            var getAccountTask = facebookClient.GetAccountAsync(FacebookSettings.UserLongAccessToken);
            await getAccountTask;
            var account = getAccountTask.Result;
            //Hiển thị thông tin ra text
            txb_UserID.Text = account.Id;
            txb_UserName.Text = account.Name;
            //Lấy danh sách các page mà Admin đang quan lý
            var getPageListTask = facebookClient.GetPageList(account.Id, FacebookSettings.UserLongAccessToken);
            await getPageListTask;
            var pageList = getPageListTask.Result;
            // Lấy fanpage ID của page cần lấy
            foreach (PageDetail item in pageList.data)
            {
                if (item.name == FacebookSettings.PageName)
                {
                    FacebookSettings.PageID = item.id;
                    FacebookSettings.PageAccessToken = item.access_token;
                }
            }
            //Hiển thị thông tin Page
            txb_PageNameDisplay.Text = FacebookSettings.PageName;
            txb_PageID.Text = FacebookSettings.PageID;
        }

        private async void btn_FBMPost_Click(object sender, EventArgs e)
        {
            PostingPara PostPara = new PostingPara();
            PostPara.access_token = FacebookSettings.PageAccessToken;
            PostPara.message = txb_FBMMessage.Text;
            PostPara.link = txb_FBMLink.Text;
            var postStatusTask = facebookClient.PostOnWallPage(FacebookSettings.PageID, PostPara);
            await postStatusTask;
            var postResultTask = postStatusTask.Result;
            if (postResultTask.errorCode == null)
            {
                MessageBox.Show($"Bài viết đăng thành công!!!\nID bài viết {postResultTask.postID}", "Success");
                txb_FBLog.Text += $"{DateTime.Now.ToString()}: Bài viết ID: {postResultTask.postID} đã được Post";  //Hiển thị Log
                txb_FBLog.Text += Environment.NewLine;
            }
            else
            {
                MessageBox.Show($"\nMã lỗi: {postResultTask.errorCode}\nMessage: {postResultTask.errorMessage}", "Error");
                txb_FBLog.Text += $"\n{DateTime.Now.ToString()}: Yêu cầu Post bị lỗi errorcode: {postResultTask.errorCode}\n";
                txb_FBLog.Text += Environment.NewLine;               
            }
        }

        private async void btn_FBASet_Click(object sender, EventArgs e)
        {
            DateTime sourceDate = new DateTime(dtp_FBASetTime.Value.Year, dtp_FBASetTime.Value.Month, dtp_FBASetTime.Value.Day, dtp_FBASetTime.Value.Hour, dtp_FBASetTime.Value.Minute, dtp_FBASetTime.Value.Second);
            DateTimeOffset dto = new DateTimeOffset(sourceDate, TimeZoneInfo.Local.GetUtcOffset(sourceDate));
            PostingPara PostPara = new PostingPara();
            PostPara.access_token = FacebookSettings.PageAccessToken;
            PostPara.message = txb_FBAMessage.Text;
            PostPara.link = txb_FBALink.Text;
            PostPara.published = "false";
            PostPara.scheduled_publish_time = dto.ToUnixTimeSeconds().ToString();
            var postStatusTask = facebookClient.PostOnWallPage(FacebookSettings.PageID, PostPara);
            await postStatusTask;
            var postResultTask = postStatusTask.Result;
            if (postResultTask.errorCode == null)
            {
                MessageBox.Show($"Bài viết set lịch đăng thành công!!!\nID bài viết {postResultTask.postID}", "Success");
                txb_FBLog.Text += $"{DateTime.Now.ToString()}: Bài viết ID: {postResultTask.postID} set lịch đăng vào {sourceDate.ToString()}";  //Hiển thị Log
                txb_FBLog.Text += Environment.NewLine;
            }
            else
            {
                MessageBox.Show($"\nMã lỗi: {postResultTask.errorCode}\nMessage: {postResultTask.errorMessage}","Error");
                txb_FBLog.Text += $"\n{DateTime.Now.ToString()}: Yêu cầu Post bị lỗi errorcode: {postResultTask.errorCode}\n";
                txb_FBLog.Text += Environment.NewLine;
            }
        }



        
        /*Weather Forecast*/
        WeatherQuery weatherQuery = new WeatherQuery();

        private void btn_ForecastWF_Click(object sender, EventArgs e)
        {
            string queryCode;
            string url = WeatherData.ForecastUrl.Replace("@LOC@", txt_Location.Text);
            queryCode = weatherQuery.GenerateQueryCode(cbb_QueryWF.SelectedValue);
            url = url.Replace("@QUERY@",queryCode);
            using (WebClient client = new WebClient())
            {

                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
        }
        private void btn_weatherschedule_Click(object sender, EventArgs e)
        {
            txb_FBLog.Text += $"Bài viết dự báo thời tiết được thiết lập đăng hằng ngày vào lúc: {dtp_SetWFPost.Value.ToShortTimeString()}";
            txb_FBLog.Text += Environment.NewLine;
            ScheduledTask.cityloc = txt_Location.Text;
            ScheduledTask.querycode = weatherQuery.GenerateQueryCode(cbb_QueryWF.SelectedValue);
            ScheduledTask.hourset = dtp_SetWFPost.Value.Hour;
            ScheduledTask.minset = dtp_SetWFPost.Value.Minute;
            ScheduledTask.secset = dtp_SetWFPost.Value.Second;            
        }

        /*WeatherFoercest sub-method*/
        private void DisplayForecast(string xml)
        {

            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            /*Khai báo 1 XmlNode*/
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txt_CityWF.Text = loc_node.SelectSingleNode("name").InnerText;
            txt_CountryWF.Text = loc_node.SelectSingleNode("country").InnerText;

            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txt_LatWF.Text = geo_node.Attributes["latitude"].Value;
            txt_LongWF.Text = geo_node.Attributes["longitude"].Value;
            txt_IdWF.Text = geo_node.Attributes["geobaseid"].Value;

            lvw_Forecast.Items.Clear();
            char degrees = (char)176;

            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {

                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);


                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;
                XmlNode status_node = time_node.SelectSingleNode("symbol");
                string status = status_node.Attributes["name"].Value;
                
                ListViewItem item = lvw_Forecast.Items.Add(time.ToLongDateString());
                item.SubItems.Add(time.ToShortTimeString());
                item.SubItems.Add(temp + degrees);
                item.SubItems.Add(status);
            }
        }

        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error\n" + ex.Message);
            }
        }
        
             

        private void btn_PreviewPost_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{weatherQuery.ExportWheatherData(txt_CityWF.Text, weatherQuery.GenerateQueryCode(cbb_QueryWF.SelectedValue))}");
        }

        private async void btn_weatherpostim_Click(object sender, EventArgs e)
        {
            PostingPara para = new PostingPara();
            para.access_token = FacebookSettings.PageAccessToken;
            para.message = weatherQuery.ExportWheatherData(txt_CityWF.Text, weatherQuery.GenerateQueryCode(cbb_QueryWF.SelectedValue));
            para.link = WeatherData.weatherWallpaperLink;
            var postStatusTask = facebookClient.PostOnWallPage(FacebookSettings.PageID, para);
            await postStatusTask;
            var postResultTask = postStatusTask.Result;
            if (postResultTask.errorCode == null)
            {
                MessageBox.Show($"Bài viết set lịch đăng thành công!!!\nID bài viết {postResultTask.postID}", "Success");
                txb_FBLog.Text += $"{DateTime.Now.ToString()}: Bài viết ID: {postResultTask.postID} dự báo thời tiết đã đăng";  //Hiển thị Log
                txb_FBLog.Text += Environment.NewLine;
            }
            else
            {
                MessageBox.Show($"\nMã lỗi: {postResultTask.errorCode}\nMessage: {postResultTask.errorMessage}", "Error");
                txb_FBLog.Text += $"\n{DateTime.Now.ToString()}: Yêu cầu Post bị lỗi errorcode: {postResultTask.errorCode}\n";
                txb_FBLog.Text += Environment.NewLine;
            }
        }

        
        /*Nhóm các Method Event về tác vụ Windows*/
        /*Menustrip Event*/

        private void changeMasterPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChangeMasterPassword f = new fChangeMasterPassword();
            f.ShowDialog();
        }
        private void closeAppWithBackgroundProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOutSubMethod();            
            notiIcon.Visible = true;
            notiIcon.ShowBalloonTip(10);
            this.Hide();
            this.ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Program was written by Huỳnh Minh Khôi \n" +
                            "Project Semester 192 (" +
                            "2019 - 2020)\n" +
                            "Teacher: PhD. Trương Đình Châu", "About", MessageBoxButtons.OK);
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOutSubMethod();
            MessageBox.Show("Log Out successfull", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Hide();
            f.ShowDialog();
            this.Show();
            if (MasterLogin.LoginFalg)
            {
                tc_Main.Enabled = true;
                mainMenu_Tool.Enabled = true;
            }
            else
            {
                tc_Main.Enabled = false;
                mainMenu_Tool.Enabled = false;
            }
        }
        private void logInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();

            f.ShowDialog();
            this.Show();
            if (MasterLogin.LoginFalg)
            {
                tc_Main.Enabled = true;
                mainMenu_Tool.Enabled = true;
            }
            else
            {
                tc_Main.Enabled = false;
                mainMenu_Tool.Enabled = false;
            }
        }
        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogOutSubMethod();
            MessageBox.Show("Log Out successfull", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*Icon in Taskbar Event*/
        private void notiIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                notiIcon.Visible = false;
                WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();
            }

        }
        
        /*MiniMenu Event*/
        private void miniMenuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This background task for post to Facebook daily", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miniMenuOpen_Click(object sender, EventArgs e)
        {
            notiIcon.Visible = false;
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void miniMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
        /*Sub Method in this Form*/
        private void LogOutSubMethod()
        {
            MasterLogin.LoginFalg = false;
            tc_Main.Enabled = false;
            mainMenu_Tool.Enabled = false;
        }

        
    }
}
