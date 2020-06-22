using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTrackingSystem.Facebook
{
    public class AccessTokenResult
    {
        public string UserAccessToken { get; set; }
        public string errorMessage { get; set; }
        public string errorCode { get; set; }
    }
}
