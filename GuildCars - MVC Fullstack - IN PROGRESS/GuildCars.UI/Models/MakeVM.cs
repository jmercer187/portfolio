using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class MakeVM
    {
        public List<Make> Makes { get; set; }

        [Required(ErrorMessage = "Please enter a vehicle make")]
        public string NameOfNewMake { get; set; }

        public Make MakeToADO { get; set; }
    }
}