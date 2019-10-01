using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.functions
{
    //Авторизация на сервере zabbix
    public class AuthFromZabbix
    {
        public string AuthString = null;
        public string ErrorString = null;
        public AuthFromZabbix(string login, string password)
        {
            Request Req = new Request
            {
                jsonrpc = "2.0",
                method = "user.login",
                id = 1,
                auth = null,
                @params = new RequestParams
                {
                    user = login,
                    password = password
                }
            };

            string ReqJson = JsonConvert.SerializeObject(Req);

            string ResJson = http_get.httpReq(ReqJson);

            Result Res = JsonConvert.DeserializeObject<Result>(ResJson);

            if (Res.result != null) AuthString = Res.result;
            if (Res.error != null) ErrorString = Res.error.data;

        }
        private class Request
        {
            public string jsonrpc { get; set; }
            public string method { get; set; }
            public RequestParams @params { get; set; }
            public int id { get; set; }
            public object auth { get; set; }
        }

        private class RequestParams
        {
            public string user { get; set; }
            public string password { get; set; }
        }

        public class Result
        {
            public string jsonrpc { get; set; }
            public string id { get; set; }
            public string result { get; set; }
            public Error error { get; set; }

        }

        public class Error {
            public int code { get; set; }
            public string message { get; set; }
            public string data { get; set; }
        }
    }
}
