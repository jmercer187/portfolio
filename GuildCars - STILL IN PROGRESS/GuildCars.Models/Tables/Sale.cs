using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int VehiclePriceId { get; set; }
        public string UserId { get; set; }
        public decimal PriceOverride { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
