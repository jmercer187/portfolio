using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            AddEditVehicleVM addVehicleVM = new AddEditVehicleVM();

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
        public ActionResult AddVehicle(AddEditVehicleVM addVehicleVM)
        {
            VehicleUI vehicle = new VehicleUI();
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            if (ModelState.IsValid)
            {
                vehicle.MakeName = addVehicleVM.MakeName;
                vehicle.ModelName = addVehicleVM.ModelName;
                vehicle.BodyStyleName = addVehicleVM.BodyStyleName;
                vehicle.TransmissionType = addVehicleVM.TransmissionName;
                vehicle.ColorName = addVehicleVM.ColorName;
                vehicle.InteriorType = addVehicleVM.InteriorName;
                vehicle.ModelYear = addVehicleVM.Year;
                vehicle.Mileage = addVehicleVM.Mileage;
                vehicle.VIN = addVehicleVM.VIN;
                vehicle.New = addVehicleVM.Type;
                vehicle.Featured = addVehicleVM.Featured;
                vehicle.VehicleDescription = addVehicleVM.Description;
                vehicle.MSRP = addVehicleVM.MSRP;
                vehicle.SalePrice = addVehicleVM.SalePrice;

                repo.InsertVehicle(vehicle);

                if (addVehicleVM.UploadedImage != null && addVehicleVM.UploadedImage.ContentLength > 0)
                {

                    string extension = Path.GetExtension(addVehicleVM.UploadedImage.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"),
                        Path.GetFileName("inventory-" + vehicle.VehicleId + extension));

                    string fileName = Path.GetFileName("inventory-" + vehicle.VehicleId + extension);
                    
                    addVehicleVM.UploadedImage.SaveAs(path);

                    vehicle.ImageFileName = fileName;

                    // maybe helpful blog post? https://asp-net-example.blogspot.in/2009/01/aspnet-fileupload-example-how-to-rename.html
                    //FileUpload FileUpload1 = new FileUpload();
                    // 

                    //FileUpload1.SaveAs("~/Images/inventory" + vehicle.VehicleId + extension);
                }
                
                repo.UpdateVehicle(vehicle);
                
                return RedirectToAction("EditVehicle/" + vehicle.VehicleId, "Admin" );
            }
            else
            {
                addVehicleVM.BodyStyle = GetBodyStylesSelectList();
                addVehicleVM.Color = GetColorsSelectList();
                addVehicleVM.Interior = GetInteriorsSelectList();
                addVehicleVM.Make = GetMakeSelectList();
                addVehicleVM.Model = GetModelSelectList();
                addVehicleVM.Transmission = GetTransmissionSelectList();

                return View(addVehicleVM);
            }
        }


        public ActionResult EditVehicle(int id)
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();
            AddEditVehicleVM editVehicleVM = new AddEditVehicleVM();
            editVehicleVM.vehicle = repo.GetVehicleById(id);

            editVehicleVM.BodyStyle = GetBodyStylesSelectList();
            editVehicleVM.Color = GetColorsSelectList();
            editVehicleVM.Interior = GetInteriorsSelectList();
            editVehicleVM.Make = GetMakeSelectList();
            editVehicleVM.Model = GetModelSelectList();
            editVehicleVM.Transmission = GetTransmissionSelectList();

            editVehicleVM.MakeName = editVehicleVM.vehicle.MakeName;
            editVehicleVM.ModelName = editVehicleVM.vehicle.ModelName;
            editVehicleVM.BodyStyleName = editVehicleVM.vehicle.BodyStyleName;
            editVehicleVM.TransmissionName = editVehicleVM.vehicle.TransmissionType;
            editVehicleVM.ColorName = editVehicleVM.vehicle.ColorName;
            editVehicleVM.InteriorName = editVehicleVM.vehicle.InteriorType;
            editVehicleVM.Year = editVehicleVM.vehicle.ModelYear;
            editVehicleVM.Mileage = editVehicleVM.vehicle.Mileage;
            editVehicleVM.VIN = editVehicleVM.vehicle.VIN;
            editVehicleVM.Type = editVehicleVM.vehicle.New;
            editVehicleVM.Featured = editVehicleVM.vehicle.Featured;
            editVehicleVM.Description = editVehicleVM.vehicle.VehicleDescription;
            editVehicleVM.MSRP = editVehicleVM.vehicle.MSRP;
            editVehicleVM.SalePrice = editVehicleVM.vehicle.SalePrice;

            
            return View(editVehicleVM);
        }

        //HTTP POST for EditVehicle form submit

        [HttpPost]
        public ActionResult DeleteVehicle(int id)
        {
            var repo = VehicleRepoFactory.CreateVehicleRepo();

            repo.DeleteVehicle(id);

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult AddMake()
        {
            MakeVM makeVM = new MakeVM();
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            makeVM.Makes = repo.GetAllMakes();

            return View(makeVM);
        }

        [HttpPost]
        public ActionResult AddMake(MakeVM makeVM)
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            if (ModelState.IsValid)
            {
                makeVM.MakeToADO = new Make();

                makeVM.MakeToADO.MakeName = makeVM.NameOfNewMake;
                
                //fake work-around until security is in place
                makeVM.MakeToADO.UserName = "test";

                repo.InsertMake(makeVM.MakeToADO);
                return RedirectToAction("AddMake", "Admin");
            }
            else
            {
                makeVM.Makes = repo.GetAllMakes();
                return View(makeVM);
            }
        }

        public ActionResult AddModel()
        {
            ModelVM modelVM = new ModelVM();
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            modelVM.Makes = GetMakeSelectList();
            modelVM.Models = repo.GetAllModels();

            return View(modelVM);
        }

        [HttpPost]
        public ActionResult AddModel(ModelVM modelVM)
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            if (ModelState.IsValid)
            {
                modelVM.ModelToADO = new Model();

                modelVM.ModelToADO.ModelName = modelVM.NameOfNewModel;
                modelVM.ModelToADO.MakeName = modelVM.MakeName;

                //fake work-around until security is in place
                modelVM.ModelToADO.UserName = "test";

                repo.InsertModel(modelVM.ModelToADO);

                return RedirectToAction("AddModel", "Admin");
            }
            else
            {

                modelVM.Makes = GetMakeSelectList();
                modelVM.Models = repo.GetAllModels();

                return View(modelVM);
            }
        }

        public ActionResult AddSpecial()
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
                        Value = type.BodyStyleName,
                    }).ToList();
        }

        private List<SelectListItem> GetColorsSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllColors()
                    select new SelectListItem()
                    {
                        Text = type.ColorName,
                        Value = type.ColorName,
                    }).ToList();
        }

        private List<SelectListItem> GetInteriorsSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllInteriors()
                    select new SelectListItem()
                    {
                        Text = type.InteriorType,
                        Value = type.InteriorType,
                    }).ToList();
        }

        private List<SelectListItem> GetMakeSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllMakes()
                    select new SelectListItem()
                    {
                        Text = type.MakeName,
                        Value = type.MakeName,
                    }).ToList();
        }

        private List<SelectListItem> GetModelSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllModels()
                    select new SelectListItem()
                    {
                        Text = type.ModelName,
                        Value = type.ModelName,
                    }).ToList();
        }

        private List<SelectListItem> GetTransmissionSelectList()
        {
            var repo = VehicleComponentsRepoFactory.CreateVehicleComponentsRepo();

            return (from type in repo.GetAllTransmissions()
                    select new SelectListItem()
                    {
                        Text = type.TransmissionType,
                        Value = type.TransmissionType,
                    }).ToList();
        }
    }
}