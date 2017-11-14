using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class SearchAPIController : ApiController
    {
        [Route("Admin/AddVehicle/{make}/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelsByMake(string make)
        {
            var repo = SearchRepoFactory.CreateSearchRepo();

            string name = make;

            List<string> models = repo.SearchModelsByMakeName(name);

            return Ok(models);
        }

        [Route("Inventory/New/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNewInventory(string searchTerm, string minYear, string maxYear, string minPrice, string maxPrice)
        {
            var repo = SearchRepoFactory.CreateSearchRepo();

            Search parameters = new Search();

            if (searchTerm != "nullvalue")
            {
                parameters.SearchTerm = searchTerm;
            }
            else
            {
                parameters.SearchTerm = null;
            }

            int minYearInt;
            bool minYearResult = int.TryParse(minYear, out minYearInt);
            if (minYearResult)
            {
                parameters.MinYear = minYearInt;
            }
            else
            {
                parameters.MinYear = null;
            }

            int maxYearInt;
            bool maxYearResult = int.TryParse(maxYear, out maxYearInt);
            if (maxYearResult)
            {
                parameters.MaxYear = maxYearInt;
            }
            else
            {
                parameters.MaxYear = null;
            }

            int minPriceInt;
            bool minPriceResult = int.TryParse(minPrice, out minPriceInt);
            if (minPriceResult)
            {
                parameters.MinPrice = minPriceInt;
            }
            else
            {
                parameters.MinPrice = null;
            }

            int maxPriceInt;
            bool maxPriceResult = int.TryParse(maxPrice, out maxPriceInt);
            if (maxPriceResult)
            {
                parameters.MaxPrice = maxPriceInt;
            }
            else
            {
                parameters.MaxPrice = null;
            }


            List<VehicleUI> vehicles = repo.SearchNewVehicles(parameters);
            
            return Ok(vehicles.OrderByDescending(v => v.SalePrice).Take(20));
        }

        [Route("Inventory/Used/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsedInventory(string searchTerm, string minYear, string maxYear, string minPrice, string maxPrice)
        {
            var repo = SearchRepoFactory.CreateSearchRepo();

            Search parameters = new Search();

            if (searchTerm != "nullvalue")
            {
                parameters.SearchTerm = searchTerm;
            }
            else
            {
                parameters.SearchTerm = null;
            }

            int minYearInt;
            bool minYearResult = int.TryParse(minYear, out minYearInt);
            if (minYearResult)
            {
                parameters.MinYear = minYearInt;
            }
            else
            {
                parameters.MinYear = null;
            }

            int maxYearInt;
            bool maxYearResult = int.TryParse(maxYear, out maxYearInt);
            if (maxYearResult)
            {
                parameters.MaxYear = maxYearInt;
            }
            else
            {
                parameters.MaxYear = null;
            }

            int minPriceInt;
            bool minPriceResult = int.TryParse(minPrice, out minPriceInt);
            if (minPriceResult)
            {
                parameters.MinPrice = minPriceInt;
            }
            else
            {
                parameters.MinPrice = null;
            }

            int maxPriceInt;
            bool maxPriceResult = int.TryParse(maxPrice, out maxPriceInt);
            if (maxPriceResult)
            {
                parameters.MaxPrice = maxPriceInt;
            }
            else
            {
                parameters.MaxPrice = null;
            }


            List<VehicleUI> vehicles = repo.SearchUsedVehicles(parameters);

            return Ok(vehicles.OrderByDescending(v => v.SalePrice).Take(20));
        }

        [Route("Sales/Index/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchAllInventory(string searchTerm, string minYear, string maxYear, string minPrice, string maxPrice)
        {
            var repo = SearchRepoFactory.CreateSearchRepo();

            Search parameters = new Search();

            if (searchTerm != "nullvalue")
            {
                parameters.SearchTerm = searchTerm;
            }
            else
            {
                parameters.SearchTerm = null;
            }

            int minYearInt;
            bool minYearResult = int.TryParse(minYear, out minYearInt);
            if (minYearResult)
            {
                parameters.MinYear = minYearInt;
            }
            else
            {
                parameters.MinYear = null;
            }

            int maxYearInt;
            bool maxYearResult = int.TryParse(maxYear, out maxYearInt);
            if (maxYearResult)
            {
                parameters.MaxYear = maxYearInt;
            }
            else
            {
                parameters.MaxYear = null;
            }

            int minPriceInt;
            bool minPriceResult = int.TryParse(minPrice, out minPriceInt);
            if (minPriceResult)
            {
                parameters.MinPrice = minPriceInt;
            }
            else
            {
                parameters.MinPrice = null;
            }

            int maxPriceInt;
            bool maxPriceResult = int.TryParse(maxPrice, out maxPriceInt);
            if (maxPriceResult)
            {
                parameters.MaxPrice = maxPriceInt;
            }
            else
            {
                parameters.MaxPrice = null;
            }


            List<VehicleUI> vehicles = repo.SearchAllVehicles(parameters);

            return Ok(vehicles.OrderByDescending(v => v.SalePrice).Take(20));
        }


    }
}
