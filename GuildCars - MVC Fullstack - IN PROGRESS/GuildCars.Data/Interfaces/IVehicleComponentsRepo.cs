using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleComponentsRepo
    {
        List<Make> GetAllMakes();
        void InsertMake(Make make);
        void UpdateMake(Make make);
        void DeleteMake(int makeId);

        List<Model> GetAllModels();
        void InsertModel(Model model);
        void UpdateModel(Model model);
        void DeleteModel(Model model);

        List<Color> GetAllColors();
        void InsertColor(Color color);
        void UpdateColor(Color color);
        void DeleteColor(Color color);

        List<Interior> GetAllInteriors();
        void InsertInterior(Interior interior);
        void UpdateInterior(Interior interior);
        void DeleteInterior(Interior interior);

        List<BodyStyle> GetAllBodyStyles();
        void InsertBodyStyle(BodyStyle bodyStyle);
        void UpdateBodyStyle(BodyStyle bodyStyle);
        void DeleteBodyStyle(BodyStyle bodyStyle);

        List<Transmission> GetAllTransmissions();

    }
}
