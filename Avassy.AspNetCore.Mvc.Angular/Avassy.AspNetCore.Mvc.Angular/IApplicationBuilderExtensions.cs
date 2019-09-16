using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace Avassy.AspNetCore.Mvc.Angular
{
    public class AngularRewriteOptions : RewriteOptions
    {
        public AngularRewriteOptions AddRewrite(string target, bool skipRemainingRules, params string[] exclusions)
        {
            var options = new AngularRewriteOptions();

            if (exclusions != null)
            {
                var exclusionStrings = exclusions.Select(e =>
                {
                    e = e.Replace("/", "\\/");

                    if (e.EndsWith('/'))
                    {
                        e += ".*";
                    }
                    else
                    {
                        e += "$.*";
                    }

                    return e;
                });

                var exclusionString = string.Join('|', exclusionStrings);

                options.AddRewrite($@"^((?!.*?\b({exclusionString})))((\w+))*\/?(\.\w{{5,}})?\??([^.]+)?$", target, skipRemainingRules);

                return options;
            }

            options.AddRewrite(@"^((\w+))*\/?(\.\w{5,})?\??([^.]+)?$", target, skipRemainingRules);

            return options;
        }
    }

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAngularRewriter(this IApplicationBuilder app, AngularRewriteOptions options)
        {
            app.UseRewriter(options);

            return app;
        }
    }
}
