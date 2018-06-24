# Avassy.AspNetCore.Mvc.ActionFilters

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.ActionFilters for more info.

## Classes

- `Avassy.AspNetCore.Mvc.ActionFilters.ExcludeUserAgentsAttribute`

## Usage

### `ExcludeUserAgentsAttribute` excludes specified user agents (UA) by UA string.

#### Parameters:

- userAgent (string, required): The UA string you want to exclude.
- redirectAction (string, required): The action of the controller you want to redirect to if the UA is excluded.
- redirectController (string, required): The controller you want to redirect to if the UA is excluded.

For the moment it doesn't check for versions below the ones you specified, but that feature will be added in the future.

Example:

```
[ExcludeUserAgents("Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko", "BrowserNotSupported", "Home")]
[ExcludeUserAgents("Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko", "BrowserNotSupported", "Home")]
public class MyCoolAppController : Controller
{
  // Your code here...
}
```

