using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portal.functions
{
    public class HostgetFromZabbix
    {
        public Result hosts;
        public HostgetFromZabbix(string AuthStr, int groupid)
        {
            Request HRequest = new Request
            {
                jsonrpc = "2.0",
                method = "host.get",
                id = 1,
                auth = AuthStr,
                @params = new RequestParams
                {
                    groupids = groupid,
                    filter = new RequestFilter
                    {
                        status = 0
                    }

                }
            };

            //Сериализация данных в json строку
            string json = JsonConvert.SerializeObject(HRequest);
            //Отправка запроса
            string result = http_get.httpReq(json);
            //Десериализация результата в объект
            hosts = JsonConvert.DeserializeObject<Result>(result);
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
            public int groupids { get; set; }
            public RequestFilter @filter { get; set; }
        }

        public class RequestFilter
        {
            public int status { get; set; }
        }


        public class Result
        {
            public string jsonrpc { get; set; }
            public List<ResultResult> result { get; set; }
            public int id { get; set; }
        }
        public class ResultResult
        {
            public int hostid { get; set; }
            public string proxy_hostid { get; set; }
            public string host { get; set; }
            public string status { get; set; }  /* Состояние и функция узла сети.
                                                   Возможные значения:
                                                0 - (по умолчанию) узел сети под наблюдением;
                                                1 - узел сети без наблюдения.*/
            public string disable_until { get; set; }
            public string error { get; set; }
            public string available { get; set; }
            public string errors_from { get; set; }
            public string lastaccess { get; set; }
            public string ipmi_authtype { get; set; }
            public string ipmi_privilege { get; set; }
            public string ipmi_username { get; set; }
            public string ipmi_password { get; set; }
            public string ipmi_disable_until { get; set; }
            public string ipmi_available { get; set; }
            public string snmp_disable_until { get; set; }
            public string snmp_available { get; set; }
            public string maintenanceid { get; set; }
            public string maintenance_status { get; set; }
            public string maintenance_type { get; set; }
            public string maintenance_from { get; set; }
            public string ipmi_errors_from { get; set; }
            public string snmp_errors_from { get; set; }
            public string ipmi_error { get; set; }
            public string snmp_error { get; set; }
            public string jmx_disable_until { get; set; }
            public string jmx_available { get; set; }
            public string jmx_errors_from { get; set; }
            public string jmx_error { get; set; }
            public string name { get; set; }
            public string flags { get; set; }
            public string templateid { get; set; }
            public string description { get; set; }
            public string tls_connect { get; set; }
            public string tls_accept { get; set; }
            public string tls_issuer { get; set; }
            public string tls_subject { get; set; }
            public string tls_psk_identity { get; set; }
            public string tls_psk { get; set; }
        }
    }
}
