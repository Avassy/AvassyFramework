using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Avassy.AspNetCore.Mvc.ActionFilters.Tests.UnitTests
{
    [TestClass]
    public class ExcludeUserAgentsActionFilterAttributeTests
    {
        [TestMethod]
        public void UserAgentMustBeExcluded()
        {
            const string userAgentStringToExclude = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko";
            const string userAgentStringToUse = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko";

            var context = new ActionExecutingContext(
                new ActionContext(
                    new DefaultHttpContext(),
                    new RouteData(),
                    new ActionDescriptor(),
                    new ModelStateDictionary()),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new TestController() );
            
            context.HttpContext.Request.Headers["User-Agent"] = userAgentStringToUse;

            var filter = new ExcludeUserAgentsAttribute(userAgentStringToExclude, "Excluded", "Test");
            filter.OnActionExecuting(context);

            var result = context.Result;

            Assert.IsTrue(result is RedirectToActionResult);
        }

        [TestMethod]
        public void UserAgentMustNotBeExcluded()
        {
            const string userAgentStringToExclude = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko";
            const string userAgentStringToUse = "Mozilla/5.0 (compatible, MSIE 11, Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";

            var context = new ActionExecutingContext(
                new ActionContext(
                    new DefaultHttpContext(),
                    new RouteData(),
                    new ActionDescriptor(),
                    new ModelStateDictionary()),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new TestController());

            context.HttpContext.Request.Headers["User-Agent"] = userAgentStringToUse;

            var filter = new ExcludeUserAgentsAttribute(userAgentStringToExclude, "Excluded", "Test");
            filter.OnActionExecuting(context);

            var result = context.Result;

            Assert.IsTrue(!(result is RedirectToActionResult));
        }
    }

    public class TestController : Controller
    {
        public IActionResult Mock()
        {
            return this.Content("OK");
        }

        public IActionResult Excluded()
        {
            return this.Content("OK");
        }
    }
}