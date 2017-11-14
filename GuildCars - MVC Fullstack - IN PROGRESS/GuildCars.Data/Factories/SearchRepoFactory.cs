using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class SearchRepoFactory
    {
        public static ISearchRepo CreateSearchRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "ADO":
                    return new SearchRepo();

                default:
                    throw new Exception("Mode value in app config is not valid.");

            }
        }
    }
}
