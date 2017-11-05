using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarborMasterFromEmployeeMgmtCA.Models
{
    public class CraftTypeRepo
    {
        private static List<CraftType> _craftTypes;

        static CraftTypeRepo()
        {
            _craftTypes = new List<CraftType>()
            {
                new CraftType {TypeOfCraft="Powerboat", CraftTypeID=1},
                new CraftType {TypeOfCraft="Sail - Monohull", CraftTypeID=2},
                new CraftType {TypeOfCraft="Sail - Multihull", CraftTypeID=3},

            };
        }

        public static List<CraftType> GetAll()
        {
            return _craftTypes;
        }
    }
}