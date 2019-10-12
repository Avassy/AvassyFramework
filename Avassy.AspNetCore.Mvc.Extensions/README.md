# Avassy.AspNetCore.Mvc.Extensions

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.Extensions for more info.

## Classes

- `Avassy.AspNetCore.Mvc.Extensions.CookieAuthenticationOptionsExtensions`
- `Avassy.AspNetCore.Mvc.Extensions.HtmlStringExtensions`

## Usage

### `CookieAuthenticationOptionsExtensions` has some handy extension methods for authentication with cookie

#### `OverrideRedirectToAccessDeniedByStatusCode` overrides the default behavior when access denied with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").


#### `OverrideRedirectToLoginByStatusCode` overrides the default behavior when not logged in with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").


#### `OverrideRedirectToLogoutByStatusCode` overrides the default behavior when not logged out with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").


#### `OverrideRedirectToReturnUrlByStatusCode` overrides the default behavior when a redirect is requested in with cookie authentication and replaces the result with a `HttpStatuscode`.

##### Parameters

- statusCode (HttpStatusCode, required): The HttpStatusCode you want to return.
- message (string, optional) : The message you want to send in the body of the response, this has content type "text/plain".
- urlsToOverride (params string[]): One or more relative paths that should return a `HttpStatusCode` (e.g. "/api").


### `HtmlStringExtensions` has some handy extension methods for strings.

#### `ToEscapedJSHtmlString` escapes a `HtmlString`.

This is useful for rendering HTML strings on you page without having to worry about XSS. 

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
