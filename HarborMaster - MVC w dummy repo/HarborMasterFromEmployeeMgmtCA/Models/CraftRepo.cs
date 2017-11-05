using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarborMasterFromEmployeeMgmtCA.Models
{
    public class CraftRepo
    {
        private static List<Craft> _crafts;

        static CraftRepo()
        {
            _crafts = new List<Craft>()
            {
                new Craft {OwnerID=1, OwnerFirstName="Kevin", OwnerLastName="Bacon", NameOfCraft="Six Degrees of Freedom", LOA=45, DockNumber=10, CraftTypeID=1, MembershipID=1 },
                new Craft {OwnerID=2, OwnerFirstName="Emma", OwnerLastName="Watson", NameOfCraft="Wingardium Leviosahhh", LOA=42, DockNumber=12, CraftTypeID=3, MembershipID=2 },
                new Craft {OwnerID=3, OwnerFirstName="Kenan", OwnerLastName="Thompson", NameOfCraft="The Good Burger", LOA=54, DockNumber=14, CraftTypeID=1, MembershipID=2 },
                new Craft {OwnerID=4, OwnerFirstName="Pablo", OwnerLastName="Pascal", NameOfCraft="The Sunspear", LOA=32, DockNumber=22, CraftTypeID=2, MembershipID=3 },

            };
        }

        public static void Add(Craft craft)
        {
            if(_crafts.Any())
            {
                craft.OwnerID = _crafts.Max(c => c.OwnerID) + 1;
            }
            else
            {
                craft.OwnerID = 1;
            }

            _crafts.Add(craft);
        }

        public static void Edit(Craft craft)
        {
            _crafts.RemoveAll(c => c.OwnerID == craft.OwnerID);
            _crafts.Add(craft);
        }

        public static void Delete(int ownerID)
        {
            _crafts.RemoveAll(c => c.OwnerID == ownerID);

        }

        public static Craft GetCraft(int ownerID)
        {
            return _crafts.FirstOrDefault(c => c.OwnerID == ownerID);
        }

        public static List<Craft> GetAll()
        {
            return _crafts;
        }
    }
}