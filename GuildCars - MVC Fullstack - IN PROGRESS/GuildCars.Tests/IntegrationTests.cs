using GuildCars.Data;
using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests
{
    [TestFixture]
    class IntegrationTests
    {
        [SetUp]
        public void init()
        {
            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GuildCarsDbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanGetAllVehicles()
        {
            var repo = new VehicleRepo();
            var vehicles = repo.GetVehicles();

            Assert.AreEqual(3, vehicles.Count);
        }

        [Test]
        public void CanGetVehicleById()
        {
            var repo = new VehicleRepo();
            VehicleUI vehicle = repo.GetVehicleById(3);

            Assert.IsNotNull(vehicle);
        }

        [Test]
        public void CanGetVehicleInfo()
        {
            var repo = new VehicleRepo();
            VehicleUI vehicle = repo.GetVehicleById(3);

            Assert.AreEqual(3, vehicle.VehicleId);
            Assert.AreEqual("Volvo", vehicle.MakeName);
            Assert.AreEqual("C-30", vehicle.ModelName);
            Assert.AreEqual("Hatchback", vehicle.BodyStyleName);
            Assert.AreEqual("Silver", vehicle.ColorName);
            Assert.AreEqual("Grey / White Racer", vehicle.InteriorType);
            Assert.AreEqual("Manual", vehicle.TransmissionType);
            Assert.AreEqual("2012", vehicle.ModelYear);
            Assert.AreEqual("45781", vehicle.Mileage);
            Assert.AreEqual(false, vehicle.New);
            Assert.AreEqual(true, vehicle.Featured);
            Assert.AreEqual(false, vehicle.Sold);
            Assert.AreEqual("a1b2c3d4e5f6g7h8i9j10", vehicle.VIN);
            Assert.AreEqual("The definition of a hot hatch.", vehicle.VehicleDescription);
            Assert.AreEqual("images/2012c30.png", vehicle.ImageFilePath);
            
        }

        [Test]
        public void CanAddVehicle()
        {
            VehicleUI vehicle = new VehicleUI();
            var repo = new VehicleRepo();

            vehicle.BodyStyleName = "Truck";
            vehicle.ColorName = "Red";
            vehicle.Featured = true;
            vehicle.ImageFilePath = "images/2016fordescape.png";
            vehicle.InteriorType = "Beige / Leather";
            vehicle.Mileage = "18564";
            vehicle.ModelName = "F-150";
            vehicle.ModelYear = "2015";
            vehicle.MSRP = 8500.00M;
            vehicle.New = false;
            vehicle.SalePrice = 7455.99M;
            vehicle.Sold = false;
            vehicle.TransmissionType = "Manual";
            vehicle.VehicleDescription = "The best selling truck in America.";
            vehicle.VIN = "t0ta11EEL3g1t";

            repo.InsertVehicle(vehicle);

            Assert.AreEqual(4, vehicle.VehicleId);
        }

        [Test]
        public void GetFeaturedVehicles()
        {
            var repo = new VehicleRepo();
            List<FeaturedVehicle> vehicles = repo.GetFeaturedVehicles();

            Assert.AreEqual(2, vehicles.Count());

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual("Ford", vehicles[0].MakeName);
            Assert.AreEqual("F-150", vehicles[0].ModelName);
            Assert.AreEqual("2017", vehicles[0].Year);
            Assert.AreEqual(17000.00M, vehicles[0].Price);
            Assert.AreEqual("images/2017f150black.png", vehicles[0].ImageFilePath);
        }

        [Test]
        public void CanGetNewVehicles()
        {
            var repo = new VehicleRepo();
            var vehicles = repo.GetNewVehicles();

            Assert.AreEqual(1, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual("Ford", vehicles[0].MakeName);
            Assert.AreEqual("F-150", vehicles[0].ModelName);
            Assert.AreEqual("Truck", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorName);
            Assert.AreEqual("Black / Grey Cloth", vehicles[0].InteriorType);
            Assert.AreEqual("Automatic", vehicles[0].TransmissionType);
            Assert.AreEqual("2017", vehicles[0].ModelYear);
            Assert.AreEqual("853", vehicles[0].Mileage);
            Assert.AreEqual(true, vehicles[0].New);
            Assert.AreEqual(true, vehicles[0].Featured);
            Assert.AreEqual(false, vehicles[0].Sold);
            Assert.AreEqual("a1b2c3d4e5f6g7h8i9j10", vehicles[0].VIN);
            Assert.AreEqual("The best selling truck in all of these here united states.", vehicles[0].VehicleDescription);
            Assert.AreEqual("images/2017f150black.png", vehicles[0].ImageFilePath);

        }

        [Test]
        public void CanGetUsedVehicles()
        {
            var repo = new VehicleRepo();
            var vehicles = repo.GetUsedVehicles();

            Assert.AreEqual(1, vehicles.Count);

            Assert.AreEqual(3, vehicles[0].VehicleId);
            Assert.AreEqual("Volvo", vehicles[0].MakeName);
            Assert.AreEqual("C-30", vehicles[0].ModelName);
            Assert.AreEqual("Hatchback", vehicles[0].BodyStyleName);
            Assert.AreEqual("Silver", vehicles[0].ColorName);
            Assert.AreEqual("Grey / White Racer", vehicles[0].InteriorType);
            Assert.AreEqual("Manual", vehicles[0].TransmissionType);
            Assert.AreEqual("2012", vehicles[0].ModelYear);
            Assert.AreEqual("45781", vehicles[0].Mileage);
            Assert.AreEqual(false, vehicles[0].New);
            Assert.AreEqual(true, vehicles[0].Featured);
            Assert.AreEqual(false, vehicles[0].Sold);
            Assert.AreEqual("a1b2c3d4e5f6g7h8i9j10", vehicles[0].VIN);
            Assert.AreEqual("The definition of a hot hatch.", vehicles[0].VehicleDescription);
            Assert.AreEqual("images/2012c30.png", vehicles[0].ImageFilePath);

        }

        [Test]
        public void GetSpecials()
        {
            var repo = new MiscRepo();
            List<Specials>specials = repo.GetSpecials();

            Assert.AreEqual(2, specials.Count());
            Assert.AreEqual(1, specials[0].SpecialId);
            Assert.AreEqual("BIG OL SPECIAL 1", specials[0].SpecialTitle);
            Assert.AreEqual("DOOT DOOTY DOOT DOOT THIS IS THE DOOM SONG DOOM DOOM DOOMIDY DOOM DOOM DOOM. buy a car plz.", specials[0].SpecialDescription);
        }

        [Test]
        public void CanGetUnsoldVehicles()
        {
            var repo = new VehicleRepo();
            var vehicles = repo.GetUnsoldVehicles();

            Assert.AreEqual(2, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual("Ford", vehicles[0].MakeName);
            Assert.AreEqual("F-150", vehicles[0].ModelName);
            Assert.AreEqual("Truck", vehicles[0].BodyStyleName);
            Assert.AreEqual("Black", vehicles[0].ColorName);
            Assert.AreEqual("Black / Grey Cloth", vehicles[0].InteriorType);
            Assert.AreEqual("Automatic", vehicles[0].TransmissionType);
            Assert.AreEqual("2017", vehicles[0].ModelYear);
            Assert.AreEqual("853", vehicles[0].Mileage);
            Assert.AreEqual(true, vehicles[0].New);
            Assert.AreEqual(true, vehicles[0].Featured);
            Assert.AreEqual(false, vehicles[0].Sold);
            Assert.AreEqual("a1b2c3d4e5f6g7h8i9j10", vehicles[0].VIN);
            Assert.AreEqual("The best selling truck in all of these here united states.", vehicles[0].VehicleDescription);
            Assert.AreEqual("images/2017f150black.png", vehicles[0].ImageFilePath);

        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new SaleRepo();
            var states = repo.GetStates();

            Assert.AreEqual(50, states.Count());
            Assert.AreEqual("AL", states[1].StateId);
            Assert.AreEqual("ALABAMA", states[1].StateName);
        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new SaleRepo();
            var types = repo.GetPurchaseMethods();

            Assert.AreEqual(3, types.Count());
            Assert.AreEqual(1, types[0].PurchaseMethodId);
            Assert.AreEqual("Cash", types[0].PurchaseType);

        }

        [Test]
        public void CanInsertSpecial()
        {
            Specials newSpecial = new Specials();
            var repo = new MiscRepo();

            newSpecial.SpecialTitle = "Test Title";
            newSpecial.SpecialDescription = "Test Description";
            
            repo.InsertSpecial(newSpecial);

            Assert.AreEqual(3, newSpecial.SpecialId);
        }

        [Test]
        public void CanGetSpecialById()
        {
            var repo = new MiscRepo();

            var special = repo.GetSpecialById(2);

            Assert.AreEqual(2, special.SpecialId);
            Assert.AreEqual("THE ONE ABOUT AMERICA", special.SpecialTitle);
            Assert.AreEqual("our greatest president, savoryhams lincols, once said that we must not be enemies but customers. let us all remember to buy a car this gettysburg memorial holiday.", special.SpecialDescription);
        }

        [Test]
        public void CanUpdateSpecial()
        {
            Specials updatedSpecial = new Specials();
            var repo = new MiscRepo();

            updatedSpecial.SpecialId = 2;
            updatedSpecial.SpecialTitle = "Updated Title";
            updatedSpecial.SpecialDescription = "Updated Description";
            
            repo.UpdateSpecial(updatedSpecial);
            var special = repo.GetSpecialById(2);

            Assert.AreEqual("Updated Title", special.SpecialTitle);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            var repo = new MiscRepo();

            repo.DeleteSpecial(1);

            var specials = repo.GetSpecials();

            Assert.AreEqual(1, specials.Count());
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new VehicleComponentsRepo();
            var bodyStyles = repo.GetAllBodyStyles();

            Assert.AreEqual(5, bodyStyles.Count());
            Assert.AreEqual(2, bodyStyles[1].BodyStyleId);
            Assert.AreEqual("Hatchback", bodyStyles[1].BodyStyleName);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = new VehicleComponentsRepo();
            var colors = repo.GetAllColors();

            Assert.AreEqual(4, colors.Count());
            Assert.AreEqual(2, colors[1].ColorId);
            Assert.AreEqual("Red", colors[1].ColorName);
        }

        [Test]
        public void CanLoadInteriors()
        {
            var repo = new VehicleComponentsRepo();
            var interiors = repo.GetAllInteriors();

            Assert.AreEqual(3, interiors.Count());
            Assert.AreEqual(2, interiors[1].InteriorId);
            Assert.AreEqual("Black / Grey Cloth", interiors[1].InteriorType);
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new VehicleComponentsRepo();
            var makes = repo.GetAllMakes();

            Assert.AreEqual(3, makes.Count());
            Assert.AreEqual(2, makes[1].MakeId);
            Assert.AreEqual("Ford", makes[1].MakeName);
            Assert.AreEqual("test", makes[1].UserName);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new VehicleComponentsRepo();
            var models = repo.GetAllModels();

            Assert.AreEqual(3, models.Count());
            Assert.AreEqual(2, models[1].ModelId);
            Assert.AreEqual("Ford", models[1].MakeName);
            Assert.AreEqual("F-150", models[1].ModelName);
            Assert.AreEqual("test", models[1].UserName);
        }

        [Test]
        public void CanLoadTransmissions()
        {
            var repo = new VehicleComponentsRepo();
            var transmissions = repo.GetAllTransmissions();

            Assert.AreEqual(2, transmissions.Count());
            Assert.AreEqual(2, transmissions[1].TransmissionId);
            Assert.AreEqual("Manual", transmissions[1].TransmissionType);
        }
    }
}
