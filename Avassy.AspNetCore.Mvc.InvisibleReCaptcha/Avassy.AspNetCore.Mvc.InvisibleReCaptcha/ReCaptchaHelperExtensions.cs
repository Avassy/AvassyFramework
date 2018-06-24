using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Text;

namespace Avassy.AspNetCore.Mvc.InvisibleReCaptcha
{
    public static class ReCaptchaHelperExtensions
    {
        public static HtmlString InvisibleReCaptchaFor(this IHtmlHelper htmlHelper, string publicKey, string elementId, string @event = "click", string beforeReCaptcha = null, bool useCookie = false)
        {
            @event = @event ??  "click";

            return new HtmlString(BuildReCaptchaForElementHtml(publicKey, elementId, @event, beforeReCaptcha, useCookie));
        }

        private static string BuildReCaptchaForElementHtml(string publicKey, string elementId, string @event, string beforeReCaptcha, bool useCookie)
        {
            var builder = new StringBuilder();

            var containerId = Guid.NewGuid();

            builder.Append(BuildReCaptchaContainerHtml(publicKey, containerId));
            builder.Append("");
            builder.Append(BuildReCaptchaScript(elementId, containerId, @event, beforeReCaptcha, useCookie));
            builder.Append("");

            return builder.ToString();
        }

        private static string BuildReCaptchaContainerHtml(string publicKey, Guid containerId)
        {
            return $"<div class=\"g-recaptcha\" id=\"{containerId}\" data-sitekey=\"{publicKey}\" data-size=\"invisible\"></div>";
        }

        private static string BuildReCaptchaScript(string elementId, Guid containerId, string @event, string beforeReCaptcha, bool useCookie)
        {
            var script =
                $@"<script type=""text/javascript"">
                window.Avassy = window.Avassy || {{}};
                window.Avassy.InvisibleReCaptcha = window.Avassy.InvisibleReCaptcha || {{
                    isReCaptchaApiScriptAlreadyInPage: false,
                    isReCaptchaApiScriptLoaded: false,
                    isInitialized: false,                    
                    
                    reCaptchaConfigs: [],

                    insertReCaptchaElementClones: function() {{
                        // This works in MS Edge and google Chrome
                        //this.captchaConfigs.forEach(config => {{ if(!config.reCaptchaElementCloneInserted) config.insertElementClone() }})

                        // This works in MS Edge and google Chrome and MS IE11
                        this.captchaConfigs.forEach(function(config) {{ if(!config.reCaptchaElementCloneInserted) config.insertElementClone() }})  
                    }},

                    initializeReCaptchas: function() {{
                        // This works in MS Edge and google Chrome
                        //this.reCaptchaConfigs.forEach(config => {{ config.initialize() }})

                        // This works in MS Edge and google Chrome and MS IE11
                        this.reCaptchaConfigs.forEach(function(config) {{ config.initialize() }})
                       
                        this.isInitialized = true;
                    }},
                
                    getReCaptchaWidgetIdForElement: function(elementId) {{
                        // This works in MS Edge and google Chrome
                        //var config = this.reCaptchaConfigs.find((c) => {{
                        //    return c.elementId === elementId;
                        //}});

                        // This works in MS Edge and google Chrome and MS IE11
                        var config;

                        this.reCaptchaConfigs.forEach(function(c) {{
                            if(c.elementId === elementId) {{
                                config = c;
                                return;
                            }}
                        }});

                        return config ? config.widgetId : null;
                    }},

                    getReCaptchaContainerIdForElement: function(elementId) {{
                        // This works in MS Edge and google Chrome
                        //var config = this.reCaptchaConfigs.find((c) => {{
                        //    return c.elementId === elementId;
                        //}});

                        // This works in MS Edge and google Chrome and MS IE11
                        var config;

                        this.reCaptchaConfigs.forEach(function(c) {{
                            if(c.elementId === elementId) {{
                                config = c;
                                return;
                            }}
                        }});

                        return config ? config.containerId : null;
                    }},

                    getReCaptchaConfigForElement: function(elementId) {{
                        // This works in MS Edge and google Chrome
                        //var config = this.reCaptchaConfigs.find((config) => {{
                        //    return config.elementId === elementId;
                        //}});

                        // This works in MS Edge and google Chrome and MS IE11
                        var config;

                        this.reCaptchaConfigs.forEach(function(c) {{
                            if(c.elementId === elementId) {{
                                config = c;
                                return;
                            }}
                        }});

                        return config;
                    }},

                    executeReCaptchaForElement: function(elementId) {{
                        var widgetId = this.getReCaptchaWidgetIdForElement(elementId);

                        return grecaptcha.execute(widgetId);
                    }},
                    
                    getReCaptchaResponseForElement: function(elementId) {{
                        var widgetId = this.getReCaptchaWidgetIdForElement(elementId);

                        return grecaptcha.getResponse(widgetId);
                    }}
                }}
                
                window.Avassy.InvisibleReCaptcha.reCaptchaConfigs.push(
                {{
                    containerId: ""{containerId}"",
                    elementId: ""{elementId}"",
                    widgetId: null,
                    event: ""{@event}"",
                    eventObject: null,
                    useCookie: {useCookie.ToString().ToLower()},
                    isInitialized: false,                        
                    data: {{}},
                    reCaptchaElementCloneInserted: false,

                    get before() {{
                        return {(string.IsNullOrEmpty(beforeReCaptcha) ? "null" : beforeReCaptcha)};
                    }},

                    get insertElementClone() {{
                        var self = this;

                        // This works in MS Edge and google Chrome
                        //return () => {{

                        // This works in MS Edge and google Chrome and MS IE11
                        return function() {{                                
    
                            var element = document.getElementById(self.elementId);                            
                            var elementClone = element.cloneNode(true);   

                            elementClone.id += ""_RecaptchaClone"";                                                       
                            elementClone[""on"" + (self.event == ""enter"" ? ""keyup"" : self.event)] = self.eventHandler;

                            element.style.display = ""none"";  
                                  
                            // This works in MS Edge and google Chrome
                            // get the original value and selectedIndex (for <select>)                         
                            //elementClone.onfocus = () => {{
                            //    self.data.originalValue = element.value;
                            //    self.data.originalIndex = element.selectedIndex                                    
                            //}};

                            // This works in MS Edge and google Chrome and MS IE11
                            // get the original value and selectedIndex (for <select>)  
                            elementClone.onfocus = function() {{
                                self.data.originalValue = element.value;
                                self.data.originalIndex = element.selectedIndex  
                            }};                               

                            if(elementClone.nodeName === ""INPUT"" || elementClone.nodeName === ""TEXTAREA"") {{

                                // This works in MS Edge and google Chrome and MS IE11
                                //elementClone.oninput = (ev) => {{
                                //    element.value = ev.target.value;
                                //}};

                                elementClone.oninput = function(ev) {{
                                    element.value = ev.target.value;
                                }};
                            }}

                            // Copy the setters
                            var elementPrototype = Object.getPrototypeOf(element);

                            Object.getOwnPropertyNames(elementPrototype).forEach(function(propertyName) {{

                                var descriptor = Object.getOwnPropertyDescriptor(elementPrototype, propertyName);

                                if(descriptor) {{
                                    var originalSet = descriptor.set;

                                    descriptor.set = function(val) {{                                
                                        elementClone[propertyName] = val;

                                        originalSet.apply(this, arguments);
                                    }};

                                    try {{ Object.defineProperty(element, propertyName, descriptor); }} catch (ex) {{}}                                        
                                }}

                            }});                             
                             
                            element.parentNode.insertBefore(elementClone, element);  

                            self.reCaptchaElementCloneInserted = true;
                        }}
                    }},
                                     
                    get initialize() {{
                        var self = this;

                        // This works in MS Edge and google Chrome
                        //return () => {{

                        // This works in MS Edge and google Chrome and MS IE11
                        return function() {{                            
                            self.widgetId = grecaptcha.render(self.containerId, {{ callback: self.callback, inherit: true }});

                            self.isInitialized = true;                                
                        }}
                    }},                        

                    get eventHandler() {{
                        var self = this;

                        // This works in MS Edge and google Chrome
                        //return (ev) => {{

                        // This works in MS Edge and google Chrome and MS IE11
                        return function(ev) {{

                            self.eventObject = ev;

                            if(self.event === ""enter"") {{
                                if(self.eventObject.keyCode !== 13) {{
                                    return;
                                }}
                            }}

                            ev.preventDefault();
                            ev.stopImmediatePropagation();

                            // Clear the cookie on the document
                            document.cookie = ""g-recaptcha-response=; expires=Thu, 01 Jan 1970 00:00:01 GMT; path=/"";

                            self.data.newValue = ev.target.value;                                  

                            if(ev.target.nodeName === ""SELECT"") {{   
                                // Prevent the change to occur till after ReCaptcha check by setting the values to the original values the selectedIndexes to the original index                           
                                self.data.newIndex = ev.target.selectedIndex;
                                ev.target.value = self.data.originalValue;
                                ev.target.selectedIndex = self.data.originalIndex;
                                ev.target.options[ev.target.selectedIndex].selected = true;
                            }}

                            if(typeof self.before === ""function"") {{
                                if(self.before.call({GetContextFromFunction(beforeReCaptcha, elementId)}, self.elementId)) {{
                                    grecaptcha.execute(self.widgetId);
                                }}
                            }} else {{
                                grecaptcha.execute(self.widgetId);
                            }}
                        }}
                    }},

                    get callback() {{
                        var self = this;

                        // This works in MS Edge and google Chrome
                        //return (response) => {{

                        // This works in MS Edge and google Chrome and MS IE11
                        return function(response) {{

                            if(self.useCookie) {{
                                // Set cookie
                                var date = new Date();

                                // Set the period in which the cookie will expire (30 seconds);
                                date.setTime(date.getTime() + 30000);

                                document.cookie = ""g-recaptcha-response="" + response + ""; expires="" + date.toUTCString() + ""; path=/"";
                            }}

                            var element = document.getElementById(self.elementId);
                            var clonedElement = document.getElementById(self.elementId  + ""_RecaptchaClone"");
                          
                            // Set the value to the new value                            
                            element.value = self.data.newValue;
                            clonedElement.value = self.data.newValue;
                            
                            if(clonedElement.nodeName === ""SELECT"") {{  
                                // Set the selected index to the new index                                   
                                element.selectedIndex = self.data.newIndex;
                                element.options[element.selectedIndex].selected = true;
                                clonedElement.selectedIndex = self.data.newIndex;
                                clonedElement.options[clonedElement.selectedIndex].selected = true; 
                            }}                                                               

                            switch (self.event) {{
                                case ""click"": element.click(); break;
                                case ""focus"": element.focus(); break;
                                case ""blur"": element.blur(); break;                               
                                       
                                // This works in MS Edge and google Chrome and MS IE11
                                default: {{                                        
                                    var event;

                                    var eventConstructorExists = typeof(Event) === ""function"";
                                    
                                    if(eventConstructorExists && self.eventObject instanceof Event) {{
                                        event = self.eventObject;
                                    }} else if(eventConstructorExists) {{
                                        event = new Event(self.event === ""enter"" ? ""keyup"" : self.event, {{ bubbles: true, cancelable: true }});
                                    }} else {{ 
                                        event = document.createEvent(""Event"");
                                        event.initEvent(self.event === ""enter"" ? ""keyup"" : self.event, true, true);                                            
                                    }}                                        

                                    if(self.event === ""enter"") {{ 
                                        event.keyCode = 13;
                                        event.which = 13;
                                    }}

                                    if(self.event === ""keyup"") {{ 
                                        event.keyCode = self.eventObject.keyCode;
                                        event.which = self.eventObject.which;
                                    }}

                                    element.dispatchEvent(event);   
                                }}; break;
                            }}                           

                            grecaptcha.reset(self.widgetId);                           
                        }}
                    }}
                }});

                window.Avassy.InvisibleReCaptcha.insertReCaptchaElementClones();

                if(window.Avassy.InvisibleReCaptcha.isReCaptchaApiScriptAlreadyInPage && window.Avassy.InvisibleReCaptcha.isReCaptchaApiScriptLoaded) {{
                    window.Avassy.InvisibleReCaptcha.initializeReCaptchas();
                }}
                
                if (!window.Avassy.InvisibleReCaptcha.isReCaptchaApiScriptAlreadyInPage) {{                  

                    var reCaptchaScript = document.createElement('script');
                    reCaptchaScript.type = 'text/javascript';
                    reCaptchaScript.async = true;
                    reCaptchaScript.defer = true;
                    reCaptchaScript.src = 'https://www.google.com/recaptcha/api.js?onload=reCaptchaApiLoaded&render=explicit';

                    var head = document.getElementsByTagName('head')[0];
                    head.appendChild(reCaptchaScript)

                    window.Avassy.InvisibleReCaptcha.isReCaptchaApiScriptAlreadyInPage = true;

                    function reCaptchaApiLoaded() {{
                        window.Avassy.InvisibleReCaptcha.isReCaptchaApiScriptLoaded = true; 
                        window.Avassy.InvisibleReCaptcha.initializeReCaptchas();
                    }}
                }};                                
                </script>";

            return script;
        }

        private static string GetContextFromFunction(string function, string elementId)
        {
            if (string.IsNullOrEmpty(function))
            {
                return "null";
            }

            // default context
            var context = $@"document.getElementById(""{elementId}"")";

            var isAnonymousFunction = function.StartsWith("function");
            var isLambdaFunction = function.Contains("=>");

            if (!isLambdaFunction && !isAnonymousFunction && function.LastIndexOf(".", StringComparison.Ordinal) > 1)
            {
                context = function.Substring(0, function.LastIndexOf(".", StringComparison.Ordinal));
            }
            
            return context;
        }
    }
}
