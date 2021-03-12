using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDBContext db;

        public SqlRestaurantData(OdeToFoodDBContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurante)
        {
            db.Restaurante.Add(restaurante);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var exis = db.Restaurante.Find(id);

            if (exis != null)
            {
                db.Restaurante.Remove(exis);
                db.SaveChanges();
            }
        }

        public void Edit(Restaurant restaurante)
        {
            var exis = db.Entry(restaurante); //si existe
            exis.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurante.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurante
                   orderby r.Name
                   select r;

        }
    }
}
