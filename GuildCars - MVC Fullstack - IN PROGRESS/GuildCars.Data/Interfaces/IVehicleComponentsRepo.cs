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
        Make GetMakeById(int makeId);
        void InsertMake(Make make);
        void UpdateMake(Make make);

        List<Model> GetAllModels();
        Model GetModelById(int modelId);
        void InsertModel(Model model);
        void UpdateModel(Model model);

        List<Color> GetAllColors();
        Color GetColorById(int colorId);
        void InsertColor(Color color);
        void UpdateColor(Color color);

        List<Interior> GetAllInteriors();
        Interior GetInteriorById(int interiorId);
        void InsertInterior(Interior interior);
        void UpdateInterior(Interior interior);

        List<BodyStyle> GetAllBodyStyles();
        BodyStyle GetBodyStyleById(int bodyStyleId);
        void InsertBodyStyle(BodyStyle bodyStyle);
        void UpdateBodyStyle(BodyStyle bodyStyle);

        List<Transmission> GetAllTransmissions();

    }
}
