using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IMiscRepo
    {
        List<Specials> GetSpecials();
        Specials GetSpecialById(int specialId);
        void InsertSpecial(Specials special);
        void UpdateSpecial(Specials special);
        void DeleteSpecial(int specialId);
        void InsertMessage(Contact message);
    }
}
