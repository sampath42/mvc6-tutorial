using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC6.Training.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC6.Training.Controllers
{
    //[Route("[controller]")]
    //[Route("home")]
    public class HomeController : Controller
    {
        MyConfig _config;
        public HomeController(MyConfig config)
        {
            this._config = config;
        }

        //[Route("index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            ViewBag.AppName = this._config.AppName;
            return View(new Person() { Name = this._config.AppName });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("home/submit",Name = "Submit")]
        public IActionResult Submit(Person person)
        {
            return View("Index", person);
        }
    }
}
