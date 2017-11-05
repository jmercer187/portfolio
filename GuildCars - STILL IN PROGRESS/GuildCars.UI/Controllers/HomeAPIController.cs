using GuildCars.Data.Factories;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    
    public class HomeAPIController : ApiController
    {
        [Route("api/home/index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult FeaturedVehicles()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            List<VehicleUI> featuredVehicles = (from vehicle in repo.GetVehicles()
                                                where vehicle.Featured == true
                                                select vehicle).ToList();

            return Ok(featuredVehicles);
        }

        
    }
}
