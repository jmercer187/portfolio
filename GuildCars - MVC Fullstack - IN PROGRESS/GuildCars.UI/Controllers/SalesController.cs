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
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            List<VehicleUI> vehicles = repo.GetUnsoldVehicles();

            return View(vehicles);
        }

        public ActionResult Details(int id)
        {
            var vehicleRepo = VehicleRepoFactory.CreateVehicleRepo();

            MakeSaleVM makeSaleVM = new MakeSaleVM();

            makeSaleVM.Vehicle = vehicleRepo.GetVehicleById(id);
            makeSaleVM.States = GetStatesSelectList();
            makeSaleVM.PurchaseMethods = GetPurchaseTypesSelectList();

            return View(makeSaleVM);
        }

        [HttpPost]
        public ActionResult Details(MakeSaleVM makeSale)
        {



            return RedirectToAction("Index");
        }


        private List<SelectListItem> GetStatesSelectList()
        {
            var repo = SaleRepoFactory.CreateSaleRepo();

            return (from state in repo.GetStates()
                    select new SelectListItem()
                    {
                        Text = state.StateId,
                        Value = state.StateId,
                    }).ToList();
        }

        private List<SelectListItem> GetPurchaseTypesSelectList()
        {
            var repo = SaleRepoFactory.CreateSaleRepo();

            return (from type in repo.GetPurchaseMethods()
                    select new SelectListItem()
                    {
                        Text = type.PurchaseType,
                        Value = type.PurchaseMethodId.ToString(),
                    }).ToList();
        }
    }
}