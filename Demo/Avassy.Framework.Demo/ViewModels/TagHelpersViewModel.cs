using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avassy.Framework.Demo.ViewModels
{
    public class TagHelpersViewModel
    {
        [Display(Name = "Enter your name")]
        public string Name { get; set; }
    }
}
