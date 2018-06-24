# Avassy.AspNetCore.Mvc.TagHelpers

See http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.TagHelpers for more info.

## Classes

- `Avassy.AspNetCore.Mvc.TagHelpers.AspPlaceholderForTagHelper`

## Usage

### `Avassy.AspNetCore.Mvc.TagHelpers.AspPlaceholderForTagHelper` sets a placeholder for the INPUT or TEXTAREA.

This helper takes the value of the `[Display(Name="Enter your name.")]` attribute and displays it as a placeholder for your INPUT or TEXTAREA.

Example:

````
<input type="text" asp-for="Name" asp-placeholder-for="Name" />
````
