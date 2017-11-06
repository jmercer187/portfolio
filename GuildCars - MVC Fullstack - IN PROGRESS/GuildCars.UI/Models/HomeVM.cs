using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomeVM
    {
        public List<FeaturedVehicle> Vehicles {get; set;}
        public List<Specials> Specials { get; set; }
    }
}