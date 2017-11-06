using GuildCars.Data.Factories;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult New()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            List<VehicleUI> vehicles = repo.GetNewVehicles();


            return View(vehicles);
        }

        public ActionResult Used()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            List<VehicleUI> vehicles = repo.GetUsedVehicles();


            return View(vehicles);
        }

        public ActionResult Details(int id)
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            VehicleUI vehicle = repo.GetVehicleById(id);



            return View(vehicle);
        }
    }
}
