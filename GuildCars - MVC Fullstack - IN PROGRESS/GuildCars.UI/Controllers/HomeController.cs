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
            var vehicleRepo = VehicleRepoFactory.CreateVehicleRepo();
            var miscRepo = MiscRepoFactory.CreateMiscRepo();

            HomeVM homeVM = new HomeVM();

            homeVM.Vehicles = vehicleRepo.GetFeaturedVehicles();
            homeVM.Specials = miscRepo.GetSpecials();

            return View(homeVM);
        }


        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ContactFromDetail(string VIN)
        {
            ContactVM contactVM = new ContactVM();

            string message = "I would like more information about the vehicle with VIN: " + VIN;

            contactVM.Message = message;

            return View("Contact", contactVM);
        }

        [HttpPost]
        public ActionResult Contact(ContactVM message)
        {
            var repo = MiscRepoFactory.CreateMiscRepo();
            Contact contactMessage = new Contact();

            if (ModelState.IsValid)
            {
                contactMessage.ContactName = message.ContactName;
                contactMessage.Email = message.Email;
                contactMessage.Phone = message.Phone;
                contactMessage.Message = message.Message;

                repo.InsertMessage(contactMessage);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(message);
            }
        }

        public ActionResult Specials()
        {
            var repo = MiscRepoFactory.CreateMiscRepo();

            List<Specials> specials = repo.GetSpecials();

            return View(specials);
        }
        
    }
}