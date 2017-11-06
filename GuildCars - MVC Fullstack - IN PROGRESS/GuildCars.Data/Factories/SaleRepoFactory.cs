using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class SaleRepoFactory
    {
        public static ISaleRepo CreateSaleRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "ADO":
                    return new SaleRepo();

                default:
                    throw new Exception("Mode value in app config is not valid.");

            }

        }
    }
}
