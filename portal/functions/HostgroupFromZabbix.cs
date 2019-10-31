using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.functions
{
    public class HostgroupFromZabbix
    {
        public HostgroupFromZabbix(string AuthString)
        {
            Request Req = new Request
            {
                jsonrpc = "2.0",
                method = "hostgroup.get",

                @Params = new Params
                {
                    real_hosts = "1"
                },

                id = 1,
                auth = AuthString,
            };

            string ReqJson = JsonConvert.SerializeObject(Req);

            string ResJson = http_get.httpReq(ReqJson);
        }


        public class Request
        {
            public string jsonrpc { get; set; }
            public string method { get; set; }

            public Params Params { get; set; }            
            public string auth { get; set; }
            public int id { get; set; }
        }

        public class Params
        {
            public string real_hosts { get; set; }
        }
    }
}
