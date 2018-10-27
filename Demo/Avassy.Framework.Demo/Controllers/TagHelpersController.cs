using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Avassy.Framework.Demo.Controllers
{
    [Route("Avassy.AspNetCore.Mvc.TagHelpers")]
    public class TagHelpersController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}