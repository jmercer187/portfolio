using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HarborMasterFromEmployeeMgmtCA.Models
{
    public class AddCraftViewModel
    {
        [Required(ErrorMessage = "Please enter a first name")]
        public string OwnerFirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        public string OwnerLastName { get; set; }
        [Required]
        [Range(1, 59, ErrorMessage ="Please enter a valid dock number" )]
        public int DockNumber { get; set; }
        public string NameOfCraft { get; set; }
        public int LOA { get; set; }
        public int CrafTypeID { get; set; }
        public int MembershipID { get; set; }


        public List<SelectListItem> CraftTypes { get; set; }
        [Required(ErrorMessage = "Please select a Membership")]
        public List<SelectListItem> MembershipTypes { get; set; }
    }
}