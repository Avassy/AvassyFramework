# Avassy.AspNetCore.Mvc.Extensions

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.Extensions for more info.

## Classes

- `Avassy.AspNetCore.Mvc.Extensions.CookieAuthenticationOptionsExtensions`
-  `Avassy.AspNetCore.Mvc.Extensions.HtmlHelperExtensions`
- `Avassy.AspNetCore.Mvc.Extensions.HtmlStringExtensions`

## Usage

### `CookieAuthenticationOptionsExtensions` has some handy extension methods for authentication with cookie

#### `OverrideRedirectToAccessDeniedByStatusCode` overrides the default behavior when access denied with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").

Example:

```
public void ConfigureServices(IServiceCollection services)
{
    //...
    
    services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        })
        .AddIdentityCookies(options =>
        {
            options.ApplicationCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });

            options.ExternalCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });
        });

	//...		

    services
        .AddMvc(options =>
        {
            if (!Debugger.IsAttached)
            {
                options.RequireHttpsPermanent = true;
            }

            options.Filters.Add(typeof(ValidateToJsonArrayAttribute));
        })
        .AddJsonOptions(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

#### `OverrideRedirectToLoginByStatusCode` overrides the default behavior when not logged in with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").

Example:

```
public void ConfigureServices(IServiceCollection services)
{
    //...
    
    services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        })
        .AddIdentityCookies(options =>
        {
            options.ApplicationCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });

            options.ExternalCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });
        });

	//...		

    services
        .AddMvc(options =>
        {
            if (!Debugger.IsAttached)
            {
                options.RequireHttpsPermanent = true;
            }

            options.Filters.Add(typeof(ValidateToJsonArrayAttribute));
        })
        .AddJsonOptions(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

#### `OverrideRedirectToLogoutByStatusCode` overrides the default behavior when not logged out with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").

Example:

```
public void ConfigureServices(IServiceCollection services)
{
    //...
    
    services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        })
        .AddIdentityCookies(options =>
        {
            options.ApplicationCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });

            options.ExternalCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });
        });

	//...		

    services
        .AddMvc(options =>
        {
            if (!Debugger.IsAttached)
            {
                options.RequireHttpsPermanent = true;
            }

            options.Filters.Add(typeof(ValidateToJsonArrayAttribute));
        })
        .AddJsonOptions(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

#### `OverrideRedirectToReturnUrlByStatusCode` overrides the default behavior when a redirect is requested in with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").

Example:

```
public void ConfigureServices(IServiceCollection services)
{
    //...
    
    services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        })
        .AddIdentityCookies(options =>
        {
            options.ApplicationCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });

            options.ExternalCookie.Configure(cookieOptions =>
            {
                cookieOptions.OverrideRedirectToAccessDeniedByStatusCode(HttpStatusCode.Forbidden, "Nope, you're not allowed to do that!", "/api");
                cookieOptions.OverrideRedirectToLoginByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");
                cookieOptions.OverrideRedirectToLogoutByStatusCode(HttpStatusCode.Unauthorized, "Nope, you must be signed in to do that!", "/api");

                cookieOptions.Cookie.HttpOnly = true;
                cookieOptions.Cookie.Expiration = TimeSpan.FromDays(150);
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                //cookieOptions.LoginPath = "/account/sign-in"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                //cookieOptions.LogoutPath = "/account/sign-out"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                //cookieOptions.AccessDeniedPath = "/account/access-denied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                cookieOptions.SlidingExpiration = true;
            });
        });

	//...		

    services
        .AddMvc(options =>
        {
            if (!Debugger.IsAttached)
            {
                options.RequireHttpsPermanent = true;
            }

            options.Filters.Add(typeof(ValidateToJsonArrayAttribute));
        })
        .AddJsonOptions(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

### `Avassy.AspNetCore.Mvc.Extensions.HtmlHelperExtensions` contains `IHtmlHelper` extension methods

#### `CreateGAAsyncScript` creates the asynchronous script code for Google Analytics.

If the ` Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleAnalyticsActionFilterAttribute` attribute is set on the controller or action, this method will generate an empty string.

See documentation on https://developers.google.com/analytics/devguides/collection/analyticsjs.

##### Parameters

- measurementId (string, required): The measurement ID that you created in the Google Analytics console.

Example:

```
\\ In your Razor view

@this.Html.CreateGAAsyncScript("UA-XXXXX-Y");
```

#### `CreateGAScript` creates the script code for Google Analytics.

If the ` Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleAnalyticsActionFilterAttribute` attribute is set on the controller or action, this method will generate an empty string.

See documentation on https://developers.google.com/analytics/devguides/collection/analyticsjs.

##### Parameters

- measurementId (string, required): The measurement ID that you created in the Google Analytics console.

Example:

```
\\ In your Razor view

@this.Html.CreateGAScript("UA-XXXXX-Y");
```

#### `CreateGTMScript` creates the script code for Google Tag Manager.

If the ` Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleTagManagerActionFilterAttribute` attribute is set on the controller or action, this method will generate an empty string.

See documentation on https://developers.google.com/tag-manager/quickstart.

##### Parameters

- containerId (string, required): The container ID that you created in the Google Tag Manager console.

Example:

```
\\ In your Razor view

@this.Html.CreateGTMScript("GTM-XXXX");
```

#### `ShouldDisableGA` checks if the `Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleAnalyticsAttribute` attribute is set on the controller or action.

If the `Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleAnalyticsAttribute` attribute is set on the controller or action, this method returns false.

Example:

```
\\ In your Razor view

@if (!this.Html.ShouldDisableGA())
{
    // Put your GA code here
}
```

#### `ShouldDisableGTM` checks if the `Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleTagManagerActionFilterAttribute` attribute is set on the controller or action.

If the `Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleTagManagerActionFilterAttribute` attribute is set on the controller or action, this method returns false.

Example:

```
\\ In your Razor view

@if (!this.Html.ShouldDisableGTM())
{
    // Put your GTM code here
}
```

### `HtmlStringExtensions` has some handy extension methods for strings.

#### `ToEscapedJSHtmlString` escapes a `HtmlString`.

This is useful for rendering HTML strings on you page without having to worry about JS injection. 

Example:

    <script type="text/javascript">
        $(function() {
            @{
                var jsonSerializerSettings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()};

                var serverViewModel = new HtmlString(JsonConvert.SerializeObject(this.Model, Formatting.None, jsonSerializerSettings)).ToEscapedJSHtmlString();
            }

            document.viewModel = new Avassy.Framework.FrameworkViewModel(@serverViewModel);
            document.viewModel.init();
        });
    </script>