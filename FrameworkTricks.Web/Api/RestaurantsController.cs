using FrameworkTricks.Application.Models;
using FrameworkTricks.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrameworkTricks.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData data;

        public RestaurantsController(IRestaurantData data)
        {
            this.data = data;
        }

        public IEnumerable<Restaurant> Get()
        {
            return data.GetAll();
        }
    }
}
