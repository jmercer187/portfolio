using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarborMasterFromEmployeeMgmtCA.Models
{
    public class CraftListViewModel
    {
        public string Owner { get; set; }
        public string MembershipType { get; set; }
        public int DockNumber { get; set; }
        public string NameOfCraft { get; set; }
        public string TypeOfCraft { get; set; }
        public int LOA { get; set; }
        public int OwnerID { get; set; }
    }
}