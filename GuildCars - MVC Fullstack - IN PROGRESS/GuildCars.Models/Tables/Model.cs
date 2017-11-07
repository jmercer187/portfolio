using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string UserName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
