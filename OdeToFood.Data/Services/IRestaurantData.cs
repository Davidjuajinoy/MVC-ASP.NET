using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);

        void Add(Restaurant restaurante);

        void Edit(Restaurant restaurante);

        void Delete(int id);
    }
}
