using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTrackingSystem.Facebook
{
    public class PostingPara
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string link { get; set; }
        public string url { get; set; }
        public string published { get; set; } //true or flase
        public string scheduled_publish_time { get; set; }
    }
}
