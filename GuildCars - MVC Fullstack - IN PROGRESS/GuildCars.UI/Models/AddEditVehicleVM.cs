using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AddEditVehicleVM
    {
        public List<SelectListItem> Make { get; set; }
        public List<SelectListItem> Model { get; set; }
        public List<SelectListItem> BodyStyle { get; set; }
        public List<SelectListItem> Transmission { get; set; }
        public List<SelectListItem> Color { get; set; }
        public List<SelectListItem> Interior { get; set; }


        public int VehicleId { get; set; }
        public VehicleUI vehicle { get; set; }

        [Required(ErrorMessage = "Please enter the model year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please enter the mileage")]
        public string Mileage { get; set; }
        [Required(ErrorMessage = "Please enter the MSRP")]
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Please enter a vehicle description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select whether the vehicle is New or Used")]
        public bool Type { get; set; }
        public bool Featured { get; set; }
        [Required(ErrorMessage = "Please enter the VIN")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Please select a make")]
        public string MakeName { get; set; }
        [Required(ErrorMessage = "Please select a model")]
        public string ModelName { get; set; }
        [Required(ErrorMessage = "Please select a body style")]
        public string BodyStyleName { get; set; }
        [Required(ErrorMessage = "Please select a transmission type")]
        public string TransmissionName { get; set; }
        [Required(ErrorMessage = "Please select a color")]
        public string ColorName { get; set; }
        [Required(ErrorMessage = "Please select an interior type")]
        public string InteriorName { get; set; }

        [Required(ErrorMessage = "Please provide an image for the vehicle")]
        public HttpPostedFileBase UploadedImage { get; set; }




    }
}