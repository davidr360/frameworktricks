﻿using FrameworkTricks.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkTricks.Application.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetBy(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(int id);
    }
}
