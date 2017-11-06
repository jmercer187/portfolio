using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
        public string ModelYear { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public bool New { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
        public string ImageFilePath { get; set; }
        public string VehicleDescription { get; set; }
    }
}
