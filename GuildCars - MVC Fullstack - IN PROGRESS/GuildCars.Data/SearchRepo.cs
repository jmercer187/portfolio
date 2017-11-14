using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.UIModels;
using GuildCars.Models.Queries;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data
{
    public class SearchRepo : ISearchRepo
    {

        public List<VehicleUI> SearchAllVehicles(Search parameters)
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("SearchAllVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters.SearchTerm == null)
                {
                    cmd.Parameters.AddWithValue("@Searchterm", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", parameters.SearchTerm);
                }

                if (parameters.MinYear == null)
                {
                    cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear == null)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice == null)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                }

                if (parameters.MaxPrice == null)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                }
                

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFileName = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];

                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (int)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<string> SearchModelsByMakeName(string makeName)
        {
            List<string> models = new List<string>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayModelsBySelectedMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeName", makeName);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string currentRow;

                        currentRow = dr["ModelName"].ToString();

                        models.Add(currentRow);
                    }
                }

                return models;
            }
        }

        public List<VehicleUI> SearchNewVehicles(Search parameters)
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("SearchNewVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters.SearchTerm == null)
                {
                    cmd.Parameters.AddWithValue("@Searchterm", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", parameters.SearchTerm);
                }

                if (parameters.MinYear == null)
                {
                    cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear == null)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice == null)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                }

                if (parameters.MaxPrice == null)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFileName = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];

                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (int)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<VehicleUI> SearchUsedVehicles(Search parameters)
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("SearchUsedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters.SearchTerm == null)
                {
                    cmd.Parameters.AddWithValue("@Searchterm", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", parameters.SearchTerm);
                }

                if (parameters.MinYear == null)
                {
                    cmd.Parameters.AddWithValue("@MinYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear == null)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice == null)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                }

                if (parameters.MaxPrice == null)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFileName = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];

                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (int)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }
    }
}
