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
        public void OnGet()
        {
            AuthFromZabbix Auth = new AuthFromZabbix("Admin", "zabbix");

            if (Auth.AuthString != null)
            {
                Message = Auth.AuthString;
            }
            else {
                Message = Auth.ErrorString;
            }
        }
    }
}