# Avassy.AspNetCore.Mvc.TagHelpers

See [http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.TagHelpers](http://www.avassy.com/framework/components/Avassy.AspNetCore.Mvc.TagHelpers) for more info.

## Demo

See a live demo at [http://demo.avassy.com/Avassy.AspNetCore.Mvc.TagHelpers](http://demo.avassy.com/Avassy.AspNetCore.Mvc.TagHelpers)

## Classes

- `Avassy.AspNetCore.Mvc.TagHelpers.AspMinifiedScriptTagHelper`
- `Avassy.AspNetCore.Mvc.TagHelpers.AspMinifiedStyleTagHelper`
- `Avassy.AspNetCore.Mvc.TagHelpers.AspPlaceholderForTagHelper`
- `Avassy.AspNetCore.Mvc.TagHelpers.AspPlaceholderLabelToggleTagHelper`
- `Avassy.AspNetCore.Mvc.TagHelpers.AspPopupTagHelper`

## Usage

To use these tag helpers, you must import them in your *_ViewImports.cshtml* file like so: `@addTagHelper *, Avassy.AspNetCore.Mvc.TagHelpers`.

---

### `AspMinifiedScriptTagHelper` minifies javascript in a SCRIPT tag.

This helper minifies javascript that is placed between SCRIPT tags.

Example:

`<script type="text/javascript" asp-minified-script> ... javascript here ... </script>`

---

### `AspMinifiedStyleTagHelper` minifies css in a STYLE tag.

This helper minifies css that is placed between STYLE tags.

Example:

`<style type="text/css" asp-minified-style> ... css here ... </style>`

---

### `AspPlaceholderForTagHelper` sets a placeholder for the INPUT or TEXTAREA.

This helper takes the value of the `[Display(Name="Enter your name.")]` attribute and displays it as a placeholder for your INPUT or TEXTAREA.

Example:

`<input type="text" asp-for="Name" asp-placeholder-for="Name" />`

---

### `AspPlaceholderLabelToggleTagHelper` toggles a placeholder and a label for the INPUT or TEXTAREA.

This helper allows you to toggle the placeholder and the label. It automatically creates a label and when you enter the input it will show this label, it's handy when entering text so you can still see what the field is called.

Example:

```
<style>
.form-group {
    position: relative;
    padding-top: 15px;
}

.toggle-label {
    position: absolute;
    padding: 0;
    margin: -15px 0 0 0;
    font-size: 11px;
}
</style>

<div class="form-group">
    <input type="text" class="form-control col-md-3" asp-placeholder-label-toggle placeholder="Enter your name" data-label-css-class="toggle-label" />
</div>
```

---

### `AspPopupTagHelper` creates a link button that pops up a window

This helper creates the link button and Javascript to pop up a new window with content specified in a `<template>` tag or by specifying the HTML content (for older browsers that do not support the `<template>` tag).

#### Attributes

- display-text (string, optional): The text that needs to be displayed on the link button.

- display-icon-css-class (string, optional): The css class of the icon that needs to be rendered, for example Bootstrap's icons. See [http://getbootstrap.com](http://getbootstrap.com "Bootstrap's's Homepage") for icons.

- display-icon-position: (string, optional, default: before): The position of the icon, *before* of *after* the display-text.

- css-class: (string, optional): The css class that needs to be applied to the link button.

- template-id (string, required when the html-content attribute is not set): the id of the `<template>` tag that contains the HTML for the popup window.

- html-content (string, required when the template-id attribute is not set): The HTML that needs to be rendered in the popup window, recommended is to build this in a razor function and put it in a variable to not clutter the `<asp-popup>` tag. *(Note: This is for browsers that do not support the `<template>` tag)*

- top (int, optional, default: vertical middle of the screen): The amount of pixels measured from the screen's top to align the popup window vertically.

- left (int, optional, default: horizontal center of the screen): The amount of pixels measured from the left side of the screen to align the popup window horizontally.

- height (int, optional, default: 500): The height of the popup window.

- width (int, optional, default: 500): The width of the popup window.


Example with template-id:

```
<!-- Razor -->

<!-- Place the styles in the <head> -->

<style>
        .styled-link {
            color: orange;
        }
</style>

<!-- Place the template preferably in the <head> but the <body> is also ok -->

<template id="info1">
    <style>
        .h1-styled {
            font-size: 20px;
            color: red;
        }
    </style>
    <h1 class="h1-styled">This is a styled title</h1>
    <p>
        This is the content
    </p>
</template>

<!-- Place the <asp-popup> as desired -->

<asp-popup display-text="Info" display-icon-css-class="fas fa-info-circle" display-icon-position="after" top="200" left="400" height="200" width="100" template-id="info1" css-class="styled-link" />
```

Example with html-content:

```
<!-- Razor -->

@{
    var html = "<h1 id=\"title\">This is the title</h1><p>This is the content</p>";
}
	 
<asp-popup display-icon-css-class="fas fa-info-circle" html-content="@html" />
```
