using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.UIModels
{
    public class VehicleUI
    {
        public int VehicleId { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public string BodyStyleName { get; set; }
        public string TransmissionType { get; set; }
        public string ColorName { get; set; }
        public string InteriorType { get; set; }
        public string ModelYear { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public bool New { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
        public string ImageFilePath { get; set; }
        public string VehicleDescription { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
    }
}
