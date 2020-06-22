using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FacebookTrackingSystem.Facebook;

namespace FacebookTrackingSystem.FacebookMain
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);

        Task<T> PostAsync<T>(string endpoint, string typepost, object data);
    }
    public class FacebookClient : IFacebookClient
    {
        //Khởi tạo 1 HttpClient

        private readonly HttpClient _httpClient;

        //Client mới đc tạo sẽ tạo 1 Http mới truy cập đến URL Graph của FB
        public FacebookClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v7.0/")
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //2 phương thức Get và Post trên Graph API FB

        //--GET--//
        public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<T> PostAsync<T>(string endpoint, string typepost, object data)
        {
            var payload = GetPayload(data);
            var response = await _httpClient.PostAsync($"{endpoint}/{typepost}", payload);
            if (!response.IsSuccessStatusCode) return default(T);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
        //------------------------------------------------------------------------------------------
        //GET thông tin tài khoản
        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var response = await _httpClient.GetAsync($"me?access_token={accessToken}&fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale");
            var result = await response.Content.ReadAsStringAsync();
            var jsonresult = JsonConvert.DeserializeObject<dynamic>(result);
            if (!response.IsSuccessStatusCode) //nếu bị lỗi
            {
                var final_return = new Account
                {
                    errorMessage = jsonresult.error.message,
                    errorCode = jsonresult.error.code
                };
                return final_return;
            }
            else //không bị lỗi
            {
                var final_return = new Account
                {
                    Id = jsonresult.id,
                    Email = jsonresult.email,
                    Name = jsonresult.name,
                    UserName = jsonresult.username,
                    FirstName = jsonresult.first_name,
                    LastName = jsonresult.last_name,
                    Locale = jsonresult.locale,
                    Birthday = jsonresult.birthday
                };
                return final_return;
            }
        }
        //GET user Long access token from short AC token

        public async Task<AccessTokenResult> GetAccessToken(string appID, string appSecret, string accessToken)
        {
            var response = await _httpClient.GetAsync($"oauth/access_token?grant_type=fb_exchange_token&client_id={appID}&client_secret={appSecret}&fb_exchange_token={accessToken}");
            var result = await response.Content.ReadAsStringAsync();
            var jsonresult = JsonConvert.DeserializeObject<dynamic>(result);
            if (!response.IsSuccessStatusCode) //nếu bị lỗi
            {
                var final_return = new AccessTokenResult
                {
                    errorMessage = jsonresult.error.message,
                    errorCode = jsonresult.error.code
                };
                return final_return;
            }
            else //không bị lỗi
            {
                var final_return = new AccessTokenResult
                {
                    UserAccessToken = jsonresult.access_token
                };
                return final_return;
            }
        }
        //GET Page List That you managed

        public async Task<PageResult> GetPageList(string userID, string userAccessToken)
        {
            var response = await _httpClient.GetAsync($"{userID}/accounts?fields=name,access_token&access_token={userAccessToken}");
            var result = await response.Content.ReadAsStringAsync();
            PageResult jsonresult = JsonConvert.DeserializeObject<PageResult>(result);
            var jsonresult2 = JsonConvert.DeserializeObject<dynamic>(result);
            if (!response.IsSuccessStatusCode) //nếu bị lỗi
            {
                var final_return = new PageResult
                {
                    errorMessage = jsonresult2.error.message
                };
                return final_return;
            }
            else //không bị lỗi
            {
                return jsonresult;
            }
        }



        public async Task<PostResult> PostPhotoOnWallPage(string endpoint, object data)
        {
            var payload = GetPayload(data);
            var response = await _httpClient.PostAsync($"{endpoint}/photos", payload);
            var result = await response.Content.ReadAsStringAsync();
            var jsonresult = JsonConvert.DeserializeObject<dynamic>(result);
            if (!response.IsSuccessStatusCode) //nếu bị lỗi
            {
                var final_return = new PostResult
                {
                    errorMessage = jsonresult.error.message,
                    errorCode = jsonresult.error.code
                };
                return final_return;
            }
            else //không bị lỗi
            {
                var final_return = new PostResult
                {
                    photoID = jsonresult.id,
                    postID = jsonresult.post_id,
                };
                return final_return;
            }
        }

        public async Task<PostResult> PostOnWallPage(string endpoint, object data)
        {
            var payload = GetPayload(data);
            var response = await _httpClient.PostAsync($"{endpoint}/feed", payload);
            var result = await response.Content.ReadAsStringAsync();
            var jsonresult = JsonConvert.DeserializeObject<dynamic>(result);
            if (!response.IsSuccessStatusCode) //nếu bị lỗi
            {
                var final_return = new PostResult
                {
                    errorMessage = jsonresult.error.message,
                    errorCode = jsonresult.error.code
                };
                return final_return;
            }
            else //không bị lỗi
            {
                var final_return = new PostResult
                {
                    postID = jsonresult.id,
                };
                return final_return;
            }
        }


        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            /*
             * JsonConvert.SerializeObject(data) chuyển kiểu dữ liệu thông thường vd string thành kiểu dữ liệu JSON
             * JSON: JavaStrip Object Notation
             */
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
