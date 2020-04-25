# Avassy.AspNetCore.Mvc.ActionFilters

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.ActionFilters for more info.

## Classes

- `Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleAnalyticsActionFilterAttribute`
- `Avassy.AspNetCore.Mvc.ActionFilters.DisableGoogleTagManagerActionFilterAttribute`
- `Avassy.AspNetCore.Mvc.ActionFilters.ExcludeUserAgentsAttribute`
- `Avassy.AspNetCore.Mvc.ActionFilters.ValidateToJsonArrayAttribute`

## Usage

### `DisableGoogleAnalyticsActionFilterAttribute` is a helper attribute for the Google Analytics extension methods in `Avassy.AspNetCore.Mvc.Extensions.HtmlHelper`.

Example:

```
[DisableGoogleAnalytics]
[Route("Admin")]
public class AdminController : Controller
{        
    public IActionResult Index()
    {
        return this.View();
    }
}
```

### `DisableGoogleTagManagerActionFilterAttribute` is a helper attribute for the Google Tag Manager extension methods in `Avassy.AspNetCore.Mvc.Extensions.HtmlHelper`.

Example:

```
[DisableGoogleTagManager]
[Route("Admin")]
public class AdminController : Controller
{        
    public IActionResult Index()
    {
        return this.View();
    }
}
```

### `ExcludeUserAgentsAttribute` excludes specified user agents (UA) by UA string.

#### Parameters:

- userAgent (string, required): The UA string you want to exclude.
- redirectAction (string, required): The action of the controller you want to redirect to if the UA is excluded.
- redirectController (string, required): The controller you want to redirect to if the UA is excluded.

For the moment it doesn't check for versions below the ones you specified, but that feature will be added in the future.

Example:

````
[ExcludeUserAgents("Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko", "BrowserNotSupported", "Home")]
[ExcludeUserAgents("Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko", "BrowserNotSupported", "Home")]
public class MyCoolAppController : Controller
{
  // Your code here...
}
````


### `ValidateToJsonArrayAttribute` validates the modelstate and returns a JSON array.

When placing this attribute on a controller method (HttpPost for example), the model will be automagically validated and return a 422 statuscode with a JSON array in it's body.

Example:

````
public class User
{
    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailExtended(ErrorMessage = "Please enter a valid email address.")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Please enter your first name.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your last name.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your password.")]
    public string Password { get; set; }
}
````

When the modelstate is not valid the result will be a HttpStatusCodeResult 422 with the following output:

````
[
    {
        "field": "lastName",
        "errorMessage": "Please enter your last name."
    },
    {
        "field": "password",
        "errorMessage": "Please enter your password."
    },
    {
        "field": "firstName",
        "errorMessage": "Please enter your first name."
    },
    {
        "field": "emailAddress",
        "errorMessage": "Please enter your email address."
    },
    {
        "field": "emailAddress",
        "errorMessage": "Please enter a valid email address."
    }
]
````
