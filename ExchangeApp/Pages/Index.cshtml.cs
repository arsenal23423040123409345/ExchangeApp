using ExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExchangeApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public Exchange Exchanges { get; set; }
        public List<Exchange> History = new List<Exchange>();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {   
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            else
            {
                Exchanges.Date = DateTime.Now;
                History.Add(Exchanges);

                //saving exchanges history to JSON file, simulating database like cookies file 
                string dir = "./Database";
                string serializationFile = Path.Combine(dir, "path.txt");
                string jsonData = JsonConvert.SerializeObject(History.ToArray(), Formatting.Indented);
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(serializationFile, true))
                {
                    writer.WriteLine(jsonData);
                }
                //fixed bug with bad writing into file
                string text = System.IO.File.ReadAllText(serializationFile);
                text = text.Replace("]"+ System.Environment.NewLine + "[", ",");
                System.IO.File.WriteAllText(serializationFile, text);
                return Page();
            }
        }
    }
}
