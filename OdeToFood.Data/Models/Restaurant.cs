using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        //Format de validar
        [Required]
        //[Display(Name ="Tipo de comida")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]


        //[DataType(DataType.Password)]
        public CuisineType Cuisine { get; set; }
    }
}
