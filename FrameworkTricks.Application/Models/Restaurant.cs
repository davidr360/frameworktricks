using FrameworkTricks.Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrameworkTricks.Application.Models
{
    public class Restaurant : Entity
    {
        [Required]
        public string Name { get; set; }

        [DisplayName("Type of Food")]
        public CuisineType Cuisine { get; set; }
    }
}
