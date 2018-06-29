using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avassy.Framework.Demo.Models
{
    public class Person
    {
        [Display(Name = "First name:")]
        [Required(ErrorMessage = "you need to fill in your first name!")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        [Required(ErrorMessage = "you need to fill in your last name!")]
        public string LastName { get; set; }

        [Display(Name = "Email addres:")]
        [Required(ErrorMessage = "you need to fill in your email address!")]
        [EmailAddress(ErrorMessage = "that email address isn't valid!")]
        public string EmailAddress { get; set; }
    }
}
