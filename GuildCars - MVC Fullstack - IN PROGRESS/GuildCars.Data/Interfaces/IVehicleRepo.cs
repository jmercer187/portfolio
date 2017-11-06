using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepo
    {
        List<VehicleUI> GetVehicles();
        VehicleUI GetVehicleById(int vehicleId);
        void InsertVehicle(VehicleUI vehicle);
        void UpdateVehicle(VehicleUI vehicle);
        void DeleteVehicle(int vehicleId);

        List<FeaturedVehicle> GetFeaturedVehicles();
        List<VehicleUI> GetNewVehicles();
        List<VehicleUI> GetUsedVehicles();
        List<VehicleUI> GetUnsoldVehicles();
       
    }
}
