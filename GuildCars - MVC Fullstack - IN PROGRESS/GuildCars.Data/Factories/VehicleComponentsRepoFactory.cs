using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class VehicleComponentsRepoFactory
    {
        public static IVehicleComponentsRepo CreateVehicleComponentsRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "ADO":
                    return new VehicleComponentsRepo();

                default:
                    throw new Exception("Mode value in app config is not valid.");

            }

        }
    }
}
