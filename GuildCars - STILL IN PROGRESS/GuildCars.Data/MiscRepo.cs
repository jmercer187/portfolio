using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data
{
    public class MiscRepo : IMiscRepo
    {
        public List<Specials> GetSpecials()
        {
            List<Specials> specials = new List<Specials>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplaySpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();

                        currentRow.SpecialId = (int)dr["SpecialId"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }
    }
}
