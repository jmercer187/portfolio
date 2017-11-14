using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class ModelVM
    {
        public List<Model> Models { get; set; }
        public Model ModelToADO { get; set; }

        public List<SelectListItem> Makes { get; set; }
        

        [Required(ErrorMessage = "A make must be selected")]
        public string MakeName { get; set; }
        
        [Required(ErrorMessage = "Please enter a model name")]
        public string NameOfNewModel { get; set; }

    }
}