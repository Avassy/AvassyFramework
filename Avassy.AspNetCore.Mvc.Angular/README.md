# Avassy.AspNetCore.Mvc.Angular

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.Angular for more info.

## Classes

- `Avassy.AspNetCore.Mvc.Angular.IApplicationBuilderExtensions`

## Usage

### `IApplicationBuilderExtensions`

#### `UseAngularRewriter` adds an Angular rewriter to the application`.

##### Parameters:

- target (string, required): The path that your app should redirect to (e.g. "index.html").
- skipRemainingRules (bool, required): Skips other rewrite rules after this one.
- exclusions (params string[]): The paths that need to be excluded from redirect (e.g. "api", this excludes http://www.myawesomesite.com/api but not http://www.myawesomesite.com/api/ | "api/", this excludes  http://www.myawesomesite.com/api/ and everything behind the /api/ path).

Example:

```
// Startup.cs

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseSession();
    app.UseAuthentication();
    
    app.UseAngularRewriter(new AngularRewriteOptions().AddRewrite("index.html", true, "api/" ));
    
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.UseMvc();
}
```
