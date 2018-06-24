## Classes

- `Avassy.AspNetCore.Mvc.InvisibleReCaptcha.ReCaptchaHelperExtensions`
- `Avassy.AspNetCore.Mvc.InvisibleReCaptcha.ReCaptchaValidationService`
- `Avassy.AspNetCore.Mvc.InvisibleReCaptcha.ValidateReCaptchaAttribute`

## Usage

### `ValidateReCaptchaAttribute` validates the g-recaptcha-response.
#### Parameters:

- secretKey (string, required): The secret key you acquired in the Google developer console.

- reCaptchaResponseNotPresentValidationMessage (string, optional, default: "The ReCaptcha response was not present."): The message for a missing reCaptcha response.

- reCaptchaResponseInvalidValidationMessage (string, optional, default: "The ReCaptcha response was not valid."): The message for an invalid reCaptcha response.


The g-recaptcha-response can be sent through the form body (default behavior for regular forms), through a request header, or through a cookie. If none of these are present the validation will fail.

Example:

    [HttpPost]
    [ValidateReCaptcha("xxxx")]
    public IActionResult Index(ContactUs model)
    {
        if (this.ModelState.IsValid)
        {
            try
            {
                return this.View("Success", model);
            }
            catch (Exception)
            {
                return this.View("Error");
            }
        }
        else
        {
            return this.View("Error");
        }
    }

### `ReCaptchaHelperExtensions` renders all the js code and markup related to the reCaptcha challenge.

#### InvisibleReCaptchaFor parameters:

- publicKey (string, required): The public key you acquired from the Google developer console.

- elementId (string, required): The element identifier on which the reCaptcha needs to be triggered

- @event (string, optional, default: click): The event you want to trigger the reCaptcha for. (Note: the parameter is called "@event" because "event" is a reserved keyword in C#).

   The event can be any event you want (ref: https://developer.mozilla.org/en-US/docs/Web/Events). You don't use "on" before the event, so instead of "onclick" you just use "click". There is also an extra event called "enter" to capture an enter key press. For enter to work you will have to add an event listener for the keyup event and check if the event.keyCode equals 13, this is because internally it also uses the keyup event.

- beforeReCaptcha (string, optional, default: null): A javascript function that needs to executed before the captcha is shown. A parameter elementId (the id of the element you triggered the event on) will be passed to the javascript function. This can be a function reference or an actual function (even lambda functions). The function needs to return true to continue the reCaptcha process. This function is typically used to validate a form before the reCaptcha is shown. But you can execute any logic you want.

   Examples:

   1. "window.validateForm"
   2. "(elementId) => { return $('#' + elementId).closest('form').valid(); }" *(Note: lambda functions don't work in IE11)*
   3. "function() { return confirm('Are you sure?'); }"
   
   
- useCookie (boolean, optional, default: false): When true, the g-recaptcha-response will be sent through a cookie (for example when using $.ajax(...) for a POST). When true, you don't have to write any logic to send the g-recaptcha-response to the server, this will work out of the box.

##### Available javascript functions and properties

There are some functions and properties you can use in your client-side logic:

###### Properties:

- window.Avassy.InvisibleReCaptchasReCaptchaApiScriptAlreadyInPage (boolean): determines if Google's reCaptcha script is already on the page.
- window.Avassy.InvisibleReCaptcha.isReCaptchaApiScriptLoaded (boolean): determines if Google's reCaptcha script is loaded.
- window.Avassy.InvisibleReCaptcha.isInitialized (boolean): determines if our custom code is initialized (reCaptchas rendered etc.).
- window.Avassy.InvisibleReCaptcha.reCaptchaConfigs (array): holds the configurations of the available reCaptchas on the page.

###### Functions:

- window.Avassy.InvisibleReCaptcha.insertReCaptchaElementClones() (void): inserts all the reCaptcha element clones.
- window.Avassy.InvisibleReCaptcha.initializeReCaptchas() (void): initializes all the reCaptchas on the page.
- window.Avassy.InvisibleReCaptcha.getReCaptchaWidgetIdForElement(elementId) (string): gets the reCaptcha widget identifier for a specified element.
- window.Avassy.InvisibleReCaptcha.getReCaptchaContainerIdForElement(elementId) (string): gets the reCaptcha container identifier for a specified element.
- window.Avassy.InvisibleReCaptcha.getReCaptchaConfigForElement(elementId) (object): gets the reCaptcha configuration for a specified element.
- window.Avassy.InvisibleReCaptcha.executeReCaptchaForElement(elementId) (void): executes the reCaptcha for a specified element.
- window.Avassy.InvisibleReCaptcha.getReCaptchaResponseForElement(elementId) (string): gets the reCaptcha response for a specified element.

##### About the reCaptchaConfigs array

This array holds the reCaptcha config objects, the reCaptcha config objects look like this:

###### Properties:

- containerId (string): The container identifier of the specified reCaptcha configuration.
- elementId (string): The element identifier of the specified reCaptcha configuration.
- widgetId (string): The widget identifier of the specified reCaptcha configuration.
- event (string): The event that needs to be triggered.
- eventObject (Event): The event that was triggered. *(Note, you will only get this object from the moment you triggered the event, also available in the beforeReCaptcha function.)*
- useCookie (boolean): Determines whether a cookie needs to be used for the specified reCaptcha configuration.
- isInitialized (boolean): Determines whether the specified reCaptcha configuration is initialized.
- data (object): Temporary data object *(can contain originalValue, newValue, originalIndex, newIndex or other temporary data)*.
- before (function): The function that needs to be called before the reCaptcha check.
- reCaptchaElementCloneInserted (boolean): Determines whether the reCaptcha element clone is inserted.

###### Functions:

*(Note: you shouldn't call these functions unless you're absolutely sure you know what you're doing!)*

- insertElementClone (void): Inserts the reCaptcha element clone.
- initialize (void): Initializes the specified reCaptcha configuration.
- eventHandler (void): The event handler for the specified reCaptcha configuration.
- callback (void): The callback for the specified reCaptcha configuration.

Example:

    <div class="container contact-us-container">
        <form asp-controller="ContactUs" asp-action="Index" method="post">
            <div class="form-group">
                <input asp-for="EmailAddress" type="email" class="form-control" aria-describedby="emailHelp" placeholder="Your email address. *">
                <small id="emailHelp" class="form-text text-muted">We'll never share your email address with anyone else.</small>
                <span asp-validation-for="EmailAddress" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input asp-for="Subject" type="text" class="form-control" placeholder="What is this about?">
            </div>
            <div class="form-group">
                <textarea asp-for="Message" class="form-control" rows="10" placeholder="Your question. *"></textarea>
                <span asp-validation-for="Message" class="text-danger"></span>
            </div>
            <div class="form-group">
                <small class="form-text text-muted">* Required fields.</small>
            </div>
            <button id="btnSubmit" type="submit" class="btn btn-primary">Submit</button>

            @this.Html.InvisibleReCaptchaFor("xxxx", "btnSubmit", "click", "function(elementId) { return $('#' + elementId).closest('form').valid(); }")
        </form>
    </div>
