using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class MakeSaleVM
    {
        public VehicleUI Vehicle { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> PurchaseMethods { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter customer's street address")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please select a state")]
        public string StateId { get; set; }
        [Required(ErrorMessage = "Please enter a Zipcode")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter the sale price")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Please select a purchase type")]
        public int PruchaseTypeId { get; set; }

    }
}