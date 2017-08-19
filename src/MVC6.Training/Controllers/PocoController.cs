using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6.Training.Controllers
{
    public class PocoController
    {
        public IActionResult Index()
        {
            return new ContentResult() { Content = "From Poco Controller" };
        }
    }
}
