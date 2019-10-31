using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.functions
{
    public class EventgetFromZabbix
    {
        public Result Events;
        public EventgetFromZabbix(string AuthStr, int triggerid, int hostid)
        {
            Request ERequest = new Request
            {
                jsonrpc = "2.0",
                method = "event.get",
                @params = new RequestParams
                {
                    output = "extend",
                    time_from = unixtime.ConvertToUnixTimestamp(DateTime.Today.AddDays(-7)),
                    select_acknowledges = "extend",
                    hostids = hostid,
                    sortfield = new List<string>(new string[] { "clock", "eventid" }),
                    sortorder = "ACS",
                    objectids = triggerid
                },
                auth = AuthStr,
                id = 1
            };

            //Сериализация данных в json строку
            string json = JsonConvert.SerializeObject(ERequest);
            //Отправка запроса
            string result = http_get.httpReq(json);
            //Десериализация результата в объект
            Result EResult = JsonConvert.DeserializeObject<Result>(result);
            Events = EResult;
        }

        public class Request
        {
            public string jsonrpc { get; set; }
            public string method { get; set; }
            public RequestParams @params { get; set; }
            public string auth { get; set; }
            public int id { get; set; }
        }

        public class RequestParams
        {
            public string output { get; set; }
            public double time_from { get; set; }
            public string select_acknowledges { get; set; }
            public int hostids { get; set; }
            public List<string> sortfield { get; set; }
            public string sortorder { get; set; }
            public int objectids { get; set; }
        }



        public class Result
        {
            public string jsonrpc { get; set; }
            public List<ResultResult> result { get; set; }
            public int id { get; set; }
        }

        public class ResultResult
        {
            public string eventid { get; set; }
            public string source { get; set; }
            public string @object { get; set; }
            public string objectid { get; set; }
            public double clock { get; set; }
            public int value { get; set; }
            public string acknowledged { get; set; }
            public string ns { get; set; }
            public string r_eventid { get; set; }
            public string c_eventid { get; set; }
            public string correlationid { get; set; }
            public string userid { get; set; }
            public List<object> acknowledges { get; set; }
        }

    }
}
