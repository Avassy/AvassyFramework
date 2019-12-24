using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Html;

namespace Avassy.AspNetCore.Mvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static bool ShouldDisableGA(this IHtmlHelper<dynamic> helper)
        {
            helper.ViewContext.RouteData.Values.TryGetValue("DisableGA", out var shouldDisableGA);

            return (bool?)shouldDisableGA ?? false;
        }

        public static HtmlString CreateGAScript(this IHtmlHelper<dynamic> helper, string measurementId)
        {
            if(string.IsNullOrEmpty(measurementId))
            {
                throw new ArgumentException("The measurementId cannot be null or empty. Did you forget to add it?", nameof(measurementId));
            }

            if (helper.ShouldDisableGA())
            {
                return HtmlString.Empty;
            }

            return new HtmlString($@"<!-- Google Analytics (async) -->
                                    <script>
                                        (function(i,s,o,g,r,a,m){{i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){{(i[r].q=i[r].q||[]).push(arguments)}},i[r].l=1*new Date();a=s.createElement(o),m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)}})(window,document,'script','https://www.google-analytics.com/analytics.js','ga');
                                        ga('create', '{measurementId}', 'auto');
                                        ga('send', 'pageview');
                                    </script>
                                    <!-- End Google Analytics (async) -->");
        }

        public static HtmlString CreateGAAsyncScript(this IHtmlHelper<dynamic> helper, string measurementId)
        {
            if (string.IsNullOrEmpty(measurementId))
            {
                throw new ArgumentException("The measurementId cannot be null or empty. Did you forget to add it?", nameof(measurementId));
            }

            if (helper.ShouldDisableGA())
            {
                return HtmlString.Empty;
            }

            return new HtmlString($@"<!-- Google Analytics -->
                                     <script>
                                         window.ga=window.ga||function(){{(ga.q = ga.q ||[]).push(arguments)}};ga.l=+new Date;
                                         ga('create', '{measurementId}', 'auto');
                                         ga('send', 'pageview');
                                     </script>
                                     <script async src='https://www.google-analytics.com/analytics.js'></script>
                                     <!-- End Google Analytics -->");
        }

        public static HtmlString CreateGTMScript(this IHtmlHelper<dynamic> helper, string containerId)
        {
            if (string.IsNullOrEmpty(containerId))
            {
                throw new ArgumentException("The containerId cannot be null or empty. Did you forget to add it?", nameof(containerId));
            }

            if (helper.ShouldDisableGA())
            {
                return HtmlString.Empty;
            }

            return new HtmlString($@"<!-- Google Tag Manager -->
                                    <script>
                                        (function(w,d,s,l,i){{w[l]=w[l]||[];w[l].push({{'gtm.start':new Date().getTime(),event:'gtm.js'}});var f=d.getElementsByTagName(s)[0],j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src='https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);}})(window,document,'script','dataLayer','{containerId}');
                                    </script>
                                    <!-- End Google Tag Manager -->");
        }
    }
}
