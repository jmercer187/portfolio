using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AddVehicleVM
    {
        public VehicleUI Vehicle { get; set; }
        public List<SelectListItem> Make { get; set; }
        public List<SelectListItem> Model { get; set; }
        public List<SelectListItem> BodyStyle { get; set; }
        public List<SelectListItem> Transmission { get; set; }
        public List<SelectListItem> Color { get; set; }
        public List<SelectListItem> Interior { get; set; }

        [Required(ErrorMessage = "Please enter the model year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please enter the mileage")]
        public string Mileage { get; set; }
        [Required(ErrorMessage = "Please enter the MSRP")]
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Please enter a vehicle description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide an image for the vehicle")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please select whether the vehicle is New or Used")]
        public bool Type { get; set; }
        public bool Featured { get; set; }
        [Required(ErrorMessage = "Please enter the VIN")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Please select a make")]
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Please select a model")]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Please select a body style")]
        public int BodyStyleId { get; set; }
        [Required(ErrorMessage = "Please select a transmission type")]
        public int TransmissionId { get; set; }
        [Required(ErrorMessage = "Please select a color")]
        public int ColorId { get; set; }
        [Required(ErrorMessage = "Please select an interior type")]
        public int InteriorId { get; set; }


    }
}