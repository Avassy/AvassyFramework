using Avassy.AspNetCore.Mvc.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace Avassy.Framework.Demo.Controllers
{

    [DisableGoogleAnalytics]
    [Route("Avassy.AspNetCore.Mvc.TagHelpers")]
    public class TagHelpersController : Controller
    {        
        public IActionResult Index()
        {
            return this.View();
        }
    }
}