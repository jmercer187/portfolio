using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();
            
            List<FeaturedVehicle> vehicles = repo.GetFeaturedVehicles();
            

            return View(vehicles);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }

        public ActionResult Specials()
        {
            var repo = MiscRepoFactory.CreateMiscRepo();

            List<Specials> specials = repo.GetSpecials();

            return View(specials);
        }
        
    }
}