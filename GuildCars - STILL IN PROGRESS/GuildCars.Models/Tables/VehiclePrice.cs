using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class VehiclePrice
    {
        public int VehiclePriceId { get; set; }
        public int VehicleId { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
