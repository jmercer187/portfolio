using GuildCars.Data.Factories;
using GuildCars.Models.UIModels;
using GuildCars.UI.Models;
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
            AddVehicleVM addVehicleVM = new AddVehicleVM();

            addVehicleVM.BodyStyle = GetBodyStylesSelectList();
            addVehicleVM.Color = GetColorsSelectList();
            addVehicleVM.Interior = GetInteriorsSelectList();
            addVehicleVM.Make = GetMakeSelectList();
            addVehicleVM.Model = GetModelSelectList();
            addVehicleVM.Transmission = GetTransmissionSelectList();

            return View(addVehicleVM);
        }

        //HTTP POST for above form submit
        [HttpPost]
        public ActionResult AddVehicle(VehicleUI vehicle)
        {

            return View();
        }

        public ActionResult EditVehicle(int id)
        {
            return View();
        }

        //HTTP POST for above form submit



        // select list transformation methods

        private List<SelectListItem> GetBodyStylesSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllBodyStyles()
                    select new SelectListItem()
                    {
                        Text = type.BodyStyleName,
                        Value = type.BodyStyleId.ToString(),
                    }).ToList();
        }

        private List<SelectListItem> GetColorsSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllColors()
                    select new SelectListItem()
                    {
                        Text = type.ColorName,
                        Value = type.ColorId.ToString(),
                    }).ToList();
        }

        private List<SelectListItem> GetInteriorsSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllInteriors()
                    select new SelectListItem()
                    {
                        Text = type.InteriorType,
                        Value = type.InteriorId.ToString(),
                    }).ToList();
        }

        private List<SelectListItem> GetMakeSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllMakes()
                    select new SelectListItem()
                    {
                        Text = type.MakeName,
                        Value = type.MakeId.ToString(),
                    }).ToList();
        }

        private List<SelectListItem> GetModelSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllModels()
                    select new SelectListItem()
                    {
                        Text = type.ModelName,
                        Value = type.ModelId.ToString(),
                    }).ToList();
        }

        private List<SelectListItem> GetTransmissionSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllTransmissions()
                    select new SelectListItem()
                    {
                        Text = type.TransmissionType,
                        Value = type.TransmissionId.ToString(),
                    }).ToList();
        }
    }
}