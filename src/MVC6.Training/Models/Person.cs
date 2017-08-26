using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6.Training.Models
{
    public class Person
    {
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
    }
}
