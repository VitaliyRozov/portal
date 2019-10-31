using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using portal.functions;

namespace portal.Pages
{
    public class testModel : PageModel
    {
        public string Message { get; set; }
        public List<(string name, int uptime)> Table;
        public void OnGet()
        {
            AuthFromZabbix Auth = new AuthFromZabbix("Admin", "zabbix");

            if (Auth.AuthString != null)
            {
                HostgetFromZabbix Hosts = new HostgetFromZabbix(Auth.AuthString, 8);

                var massiv = new List<(string name, string name1)>();
                double uptime = 0;
                double prev = -1;
                //Переберем все хосты
                for (int x = 0; x < Hosts.hosts.result.Count; x++)
                {
                    //TriggergetFromZabbix Trigger = new TriggergetFromZabbix(Auth.AuthString, Hosts.hosts.result[x].hostid);
                    EventgetFromZabbix Events = new EventgetFromZabbix(Auth.AuthString, 14005, Hosts.hosts.result[x].hostid);
                    for (int i=1; i<Events.Events.result.Count(); i++)
                    {
                        if (Events.Events.result[i].value == 1)
                        {
                            //До этого был в сети
                            if (prev == -1)
                            {
                                uptime = unixtime.ConvertToUnixTimestamp(DateTime.Today.AddDays(-7)) - Events.Events.result[i].clock;
                            }

                            {

                            }
                        }
                        else
                        {
                            //До этого был не в сети
                        }
                    }
                    massiv.Add((Hosts.hosts.result[x].name, Hosts.hosts.result[x].name));
                }

                Table = massiv;

            }
            else {
                Message = Auth.ErrorString;
            }
        }
    }
}