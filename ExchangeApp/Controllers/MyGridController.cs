using Microsoft.AspNetCore.Mvc;
using Omu.AwesomeMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApp.Controllers
{
    public class MyGridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
