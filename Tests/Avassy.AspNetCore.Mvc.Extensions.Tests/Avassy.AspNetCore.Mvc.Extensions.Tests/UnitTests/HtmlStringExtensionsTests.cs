using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Avassy.AspNetCore.Mvc.Extensions.Tests
{
    [TestClass]
    public class HtmlStringExtensionsTests
    {
        [TestMethod]
        public void HtmlStringShouldBeEscaped()
        {
            var scriptString = "<script type='text/javascript'>alert('ok');</script>";

            var scriptHtmlString = new HtmlString(scriptString);

            var escapedScriptHtmlString = scriptHtmlString.ToEscapedJSHtmlString();

            Assert.IsTrue(escapedScriptHtmlString.Value == "<script type='text\\/javascript'>alert('ok');<\\/script>");
        }
    }
}
