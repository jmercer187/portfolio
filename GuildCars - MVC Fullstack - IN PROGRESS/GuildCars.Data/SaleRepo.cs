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
    public class SaleRepo : ISaleRepo
    {
        public List<PurchaseMethod> GetPurchaseMethods()
        {
            List<PurchaseMethod> methods = new List<PurchaseMethod>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayPurchaseTypes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseMethod currentRow = new PurchaseMethod();

                        currentRow.PurchaseMethodId = (int)dr["PurchaseMethodId"];
                        currentRow.PurchaseType = dr["PurchaseType"].ToString();

                        methods.Add(currentRow);
                    }
                }
            }

            return methods;
        }

        

        public List<AddressState> GetStates()
        {
            List<AddressState> states = new List<AddressState>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayStates", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AddressState currentRow = new AddressState();
                        
                        currentRow.StateId = dr["StateId"].ToString();
                        currentRow.StateName = dr["StateName"].ToString();

                        states.Add(currentRow);
                    }
                }
            }

            return states;
        }
    }
}
