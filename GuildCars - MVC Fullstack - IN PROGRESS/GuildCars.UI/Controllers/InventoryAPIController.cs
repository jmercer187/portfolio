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
    public class InventoryAPIController : ApiController
    {
        [Route("api/Inventory/New")]
        [AcceptVerbs("GET")]
        public IHttpActionResult NewInventory()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            List<VehicleUI> newVehicles = (from vehicle in repo.GetVehicles()
                                           where vehicle.New == true && vehicle.Sold == false
                                           orderby vehicle.SalePrice descending
                                           select vehicle
                                           ).ToList();
            
            return Ok(newVehicles.Take(20));
        }

        [Route("api/Inventory/Used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult UsedInvetory()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            List<VehicleUI> usedVehicles = (from vehicle in repo.GetVehicles()
                                            where vehicle.New == false && vehicle.Sold == false
                                            orderby vehicle.SalePrice descending
                                            select vehicle).ToList();

            return Ok(usedVehicles.Take(20));
        }

    }
}
