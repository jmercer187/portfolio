using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISearchRepo
    {
        List<VehicleUI> SearchUsedVehicles(Search parameters);
        List<VehicleUI> SearchNewVehicles(Search parameters);
        List<VehicleUI> SearchAllVehicles(Search parameters);
        List<string> SearchModelsByMakeName(string makeName);
    }
}
