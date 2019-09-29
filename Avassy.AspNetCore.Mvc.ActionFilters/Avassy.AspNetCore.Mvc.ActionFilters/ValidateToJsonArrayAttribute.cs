using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avassy.NetCore.Global.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Avassy.AspNetCore.Mvc.ActionFilters
{
    public class ValidateToJsonArrayAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ObjectResult(this.CreateJsonValidationArray(context.ModelState)) { StatusCode = 422 };
            }
        }

        public IEnumerable<ValidationErrorResponse> CreateJsonValidationArray(ModelStateDictionary modelState)
        {
            var keys = modelState.Keys.ToList();

            var validationErrorResponses = new List<ValidationErrorResponse>();

            foreach (var key in keys)
            {
                var modelStateEntry = modelState[key];

                foreach (var modelStateError in modelStateEntry.Errors)
                {
                    var validationErrorResponse = new ValidationErrorResponse(key, modelStateError.ErrorMessage);

                    validationErrorResponses.Add(validationErrorResponse);
                }
            }

            return validationErrorResponses.ToArray();
        }
    }

    public class ValidationErrorResponse
    {
        private string _field = string.Empty;

        public string Field
        {
            get => this._field;
            set => this._field = value.ToCamelCase();
        }

        public string ErrorMessage { get; set; }

        public ValidationErrorResponse(string field, string errorMessage)
        {
            this.Field = field;
            this.ErrorMessage = errorMessage;
        }
    }
}
