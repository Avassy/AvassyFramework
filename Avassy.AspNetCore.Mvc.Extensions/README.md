# Avassy.AspNetCore.Mvc.Extensions

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.Extensions for more info.

## Classes

- `Avassy.AspNetCore.Mvc.Extensions.HtmlStringExtensions`

## Usage

### `HtmlStringExtensions` has some handy extension methods.

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
