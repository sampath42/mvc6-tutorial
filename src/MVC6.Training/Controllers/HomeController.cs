using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC6.Training.Models;
using MVC6.Training.Filters;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC6.Training.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        MyConfig _config;
        public HomeController(MyConfig config)
        {
            this._config = config;
        }

        [Route("index")]
        [Route("~/")]
        public IActionResult Index([FromServices] IFoo foo)
        {
            ViewBag.AppName = this._config.AppName;
            ViewBag.FromServices = foo.GetFoo();
            return View(new Person() { Name = this._config.AppName });
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return new ContentResult() { Content = "About" };
        }

        //[Route("{action=contact}")]
        public IActionResult Contact()
        {
            return new ContentResult() { Content = "Contact" };
        }

        [Route("RouteParameters")]
        [Route("RouteParameters/{s?}")]
        [Route("RouteParameters/{s}/{i?}")]
        [Route("RouteParameters/{s}/{i}")]
        public string RouteParameters(string s, int i = 10)
        {
            return $"{i} and {s}";
        }

        [Route("defaultparam/{type=en}")]
        public IActionResult DefaultRouteParamValue(string type)
        {
            return new ContentResult() { Content = type };
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost("home/submit",Name = "Submit")]
        //[ServiceFilter(typeof(LogFilter))]
        [TypeFilter(typeof(LogFilter),Arguments = new object[] { "myLogger"})]
        public IActionResult Submit(Person person)
        {
            return View("Index", person);
        }
    }
}
