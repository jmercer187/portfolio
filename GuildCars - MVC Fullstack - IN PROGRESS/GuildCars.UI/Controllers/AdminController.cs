using GuildCars.Data.Factories;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();
            List<VehicleUI> vehicles = new List<VehicleUI>();
                
            vehicles = repo.GetUnsoldVehicles();

            return View(vehicles);
        }

        public ActionResult AddVehicle()
        {
            VehicleUI vehicle = new VehicleUI();

            return View(vehicle);
        }

        //HTTP POST for above form submit

        public ActionResult EditVehicle(int id)
        {
            return View();
        }

        //HTTP POST for above form submit
    }
}