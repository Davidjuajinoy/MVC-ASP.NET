using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OddeToFood.Web.Api
{
    public class RestaurantController : ApiController
    {
        //curl https://localhost:44321/api/restaurant para ver el array

        private readonly IRestaurantData db;
        public RestaurantController(IRestaurantData db)
        {
            this.db = db;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();

            return model;
        }
    }
}
