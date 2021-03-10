using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian},
            };
        }

        public void Add(Restaurant restaurante)
        {
            restaurants.Add(restaurante);
            restaurante.Id = restaurants.Max(x => x.Id) + 1;
        }

        public void Edit(Restaurant restaurante)
        {
            var existe  = Get(restaurante.Id);

            if (existe != null)
            {
                existe.Name = restaurante.Name;
                existe.Cuisine = restaurante.Cuisine;
            }
            
            //restaurants[restaurante.Id - 1] = new Restaurant { Id = restaurante.Id, Name = restaurante.Name, Cuisine = restaurante.Cuisine };
            
            
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
