using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Omu.AwesomeMvc;

namespace ExchangeApp.Pages
{


    public class HistoryModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Exchange Exchanges { get; set; }
        public List<Exchange> History { get; set; }

        public void OnGet()
        {
            string dir = "./Database";
            string serializationFile = Path.Combine(dir, "path.txt");
            string json = System.IO.File.ReadAllText(serializationFile);
            History = JsonConvert.DeserializeObject<List<Exchange>>(json);
        }
    }
}
