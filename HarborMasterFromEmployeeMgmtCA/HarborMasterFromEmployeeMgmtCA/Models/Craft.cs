using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HarborMasterFromEmployeeMgmtCA.Models
{
    public class Craft
        
    {
        public int OwnerID { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public int DockNumber { get; set; }
        public string NameOfCraft { get; set; }
        public int LOA { get; set; }
        public int CraftTypeID { get; set; }
        public int MembershipID { get; set; }

    }
}