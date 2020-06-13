using FrameworkTricks.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkTricks.Application.Models
{
    public class Restaurant : Entity
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
