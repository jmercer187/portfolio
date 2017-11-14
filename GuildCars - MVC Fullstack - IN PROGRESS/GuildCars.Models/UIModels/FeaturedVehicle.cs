using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.UIModels
{
    public class FeaturedVehicle
    {
        public int VehicleId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string Year { get; set; }
        public string ImageFileName { get; set; }
        public decimal Price { get; set; }
    }
}
