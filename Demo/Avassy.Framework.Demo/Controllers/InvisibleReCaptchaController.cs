using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avassy.AspNetCore.Mvc.InvisibleReCaptcha;
using Avassy.Framework.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avassy.Framework.Demo.Controllers
{
    [Route("invisible-recaptcha")]
    public class InvisibleReCaptchaController : Controller
    {
        private const string _secretKey = "6LfCq1gUAAAAAOgHTYuQkBTXcgLb9veO-FGKAerv";

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateReCaptcha(secretKey: _secretKey)]
        [ValidateAntiForgeryToken]
        public IActionResult Post([Bind(Prefix = "PostPerson")]Person model)
        {
            if (this.ModelState.IsValid)
            {
                this.ViewBag.PostSuccessMessage = $"You sucessfully added {model.FirstName} {model.LastName}.";
            }
            else
            {
                this.ViewBag.PostErrorMessage = $"You must complete all the fields and reCaptcha correctly.";
            }

            return this.View("Index");
        }

        [HttpPost]
        [Route("ajaxpost")]
        [ValidateReCaptcha(secretKey: _secretKey)]
        public IActionResult AjaxPost([FromBody]Person model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Json(new { message = $"You sucessfully added {model.FirstName} {model.LastName}.", person = model });
            }

            return this.BadRequest(new { message = $"You must complete all the fields and reCaptcha correctly.", person = model });
        }
    }
}
