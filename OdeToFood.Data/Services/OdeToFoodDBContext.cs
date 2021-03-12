using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
/*  
 *Se hereda la clase DbContext y se agrega el using  
 */
    public class OdeToFoodDBContext : DbContext
    {

        public DbSet<Restaurant> Restaurante{ get; set; }

    }
}
